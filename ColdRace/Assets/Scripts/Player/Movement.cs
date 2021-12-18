using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Components and Variables:
    [HideInInspector]
    public Rigidbody2D rb;
    public Player player;

    [Header("Stats:")]
    public float speed;
    public float jumpForce;
    public float dashSpeed;
    public float dashTime;
    public float dashJump;
    public float slidingSpeed;
    public float climbSpeed;
    public int jumps = 1;
    public float gravityScale;

    [Space]
    [Header("Ground Check:")]
    public LayerMask ground;
    public Transform groundCheck;
    public float groundCheckRadius;
    public bool isGrounded;

    [Space]
    [Header("Wall Check:")]
    public bool wallSliding;
    public float wallCheckRadius;
    public Transform rightCheck;
    public bool isOnWall;
    public bool wallJumping;
    public bool wallClimbing;
    public float xWall;
    public float yWall;
    public float wallJumpTime;
    
    [Space]
    [Header("Camera:")]
    public float shakeMagnetude;
    public float shakeTime;
    public Camera mainCamera;

    [Space]
    [Header("Particles:")]
    public ParticleSystem dashFX;
    public ParticleSystem slidingFX;
    public ParticleSystem walkFX;
    public ParticleSystem deathFX;


    [Space]
    [Header("Bools:")]
    public bool facingRight;
    public bool canDash;
    public bool dashUp;
    public bool dashDiag;
    public bool canMove;
    public bool isJumping;
    public bool isDashing;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }
    

    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);


        if(isGrounded){
            canDash = true;
            isJumping = false;
            jumps = 1;
        }

        //Methods:
        if(canMove){
            Walk(dir);
            Jump();
            WallSlide(x, y);
            Dash(x, y);
            if (!wallJumping)
            {
                Flip(x);
            }
            
        }
        
    }

    void Walk(Vector2 dir){
        rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), 10 * Time.deltaTime);
        
    }   

    // Jumping
    void Jump() {

        if(Input.GetButtonDown("Jump") && isGrounded && jumps > 0 && !PauseMenu.isPaused){
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
            jumps--;
            isJumping = true;
            slidingFX.Play();
        
        }


         //Creates a Circle on Player's feet that will check for collisions with the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);

    }


    //Wall Slide/Jump
    void WallSlide(float x, float y){

        isOnWall = Physics2D.OverlapCircle(rightCheck.position, wallCheckRadius, ground);

        // Wall Climbing
        if(isOnWall && Input.GetButton("Climb")){
            rb.velocity = new Vector2(rb.velocity.x, climbSpeed * y);
            wallClimbing = true;
            slidingFX.Play();
            rb.gravityScale = 0;
        }else{
            wallClimbing = false;
            rb.gravityScale = gravityScale;
        }

        //Wall Sliding
        if (isOnWall && !isGrounded && x != 0 && !PauseMenu.isPaused && !wallClimbing) {
            wallSliding = true;
            slidingFX.Play();
            rb.velocity = new Vector2(rb.velocity.x, -slidingSpeed);
            



            //Wall Jumping
            if (Input.GetButtonDown("Jump") && !wallJumping && !PauseMenu.isPaused){
                wallJumping = true;
                Invoke("WallJumpingTime", wallJumpTime);
                rb.velocity = new Vector2(xWall * -x, yWall);
                if (facingRight)
                {
                    transform.Rotate(0f, 180f, 0f);
                    facingRight = false;
                }
                else
                {
                    transform.Rotate(0f, -180f, 0f);
                    facingRight = true;
                }

            }

            

        }else{
            wallSliding = false;
            
        }

    }

    void WallJumpingTime(){
        wallJumping = false;
    }


    // Dashing
    void Dash(float x, float y){

        if(Input.GetButtonDown("Dash") && canDash && !PauseMenu.isPaused){
            
            dashFX.Play();
            FindObjectOfType<SoundManager>().Play("dash");
            ShakeCamera();
            canDash = false;
            
            
            if(x == 0 && y == 0){
                if(facingRight){
                    rb.velocity = new Vector2(dashSpeed, rb.velocity.y);
                }else{
                    rb.velocity = new Vector2(-dashSpeed, rb.velocity.y);
                }
            }else{

                rb.velocity = new Vector2(dashSpeed * x, dashJump * y);


                
            }
            
        }
    }

    //Flip the Character
    void Flip(float x){

        if(x > 0 && !facingRight && !wallJumping){
            facingRight = true;
            transform.Rotate(0f, 180f, 0f);
            walkFX.Play();



        }else if(x < 0 && facingRight && !wallJumping)
        {
            facingRight = false;
            transform.Rotate(0f, -180f, 0f);
            walkFX.Play();

        }
    }



    // CAMERA SHAKING

	public void ShakeCamera()
	{
		InvokeRepeating ("StartCameraShaking", 0f, 0.005f);
		Invoke ("StopCameraShaking", shakeTime);
	}

	void StartCameraShaking()
	{
		float cameraShakingOffsetX = Random.value * shakeMagnetude * 2 - shakeMagnetude;
		float cameraShakingOffsetY = Random.value * shakeMagnetude * 2 - shakeMagnetude;
		Vector3 cameraIntermadiatePosition = mainCamera.transform.position;
		cameraIntermadiatePosition.x += cameraShakingOffsetX;
		cameraIntermadiatePosition.y += cameraShakingOffsetY;
		mainCamera.transform.position = cameraIntermadiatePosition;
	}

	void StopCameraShaking()
	{
		CancelInvoke ("StartCameraShaking");
	}
    

    

}
