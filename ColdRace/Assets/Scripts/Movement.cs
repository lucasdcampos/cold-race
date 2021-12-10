using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Components and Variables:
    [HideInInspector]
    public Rigidbody2D rb;
    public AnimationController anim;
    public Vector3 respawnPoint;

    [Header("Stats:")]
    public float speed;
    public float jumpForce;
    public float dashSpeed;
    public float dashTime;
    public float dashJump;
    public float slidingSpeed;
    public float climbSpeed;
    public int jumps = 1;
    public float currentStamina;
    public float maxStamina;

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
    public bool isTouchingRight;
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



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<AnimationController>();
        respawnPoint = transform.position;
    }
    

    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);


        if(wallSliding || isGrounded){
            canDash = true;
            jumps = 1;
        }

        //Methods:
        if(canMove){
            Walk(dir);
            Jump();
            WallSlide(x, y);
            Dash(x, y);
            Flip(x);
        }
        
    }

    void Walk(Vector2 dir){
        rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), 10 * Time.deltaTime);
        
    }   

    // Jumping
    void Jump() {

        if(Input.GetKeyDown("space") && isGrounded && jumps > 0 && !PauseMenu.isPaused){
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
            jumps--;
            slidingFX.Play();
        }

         //Creates a Circle on Player's feet that will check for collisions with the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);

    }

    //Wall Slide/Jump
    void WallSlide(float x, float y){

        isTouchingRight = Physics2D.OverlapCircle(rightCheck.position, wallCheckRadius, ground);

        if(currentStamina > maxStamina){
            currentStamina = maxStamina;
            
        }

        // Wall Climbing
        if(isTouchingRight && Input.GetKey("e") && currentStamina > 0){
            rb.velocity = new Vector2(rb.velocity.x, climbSpeed * y);
            rb.gravityScale = 0;
            wallClimbing = true;
            currentStamina -= Time.deltaTime;
            slidingFX.Play();
        }else{
            wallClimbing = false;
            rb.gravityScale = 3;
            currentStamina += Time.deltaTime;
        }
        if(isTouchingRight && !isGrounded && rb.velocity.x != 0 && !PauseMenu.isPaused){
            wallSliding = true;
            slidingFX.Play();

            //Wall Jumping
            if(Input.GetKeyDown("space") && !wallJumping && !PauseMenu.isPaused){
                wallJumping = true;
                Invoke("WallJumpingTime", wallJumpTime);
                rb.velocity = new Vector2(xWall * -x, yWall);
                if(x > 0 && !facingRight){
                    facingRight = true;
                    transform.Rotate(0f, 180f, 0f);


                }else if(x < 0 && facingRight){
                    facingRight = false;
                    transform.Rotate(0f, -180f, 0f);
                }
            }

            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -slidingSpeed, float.MaxValue));

        }else{
            wallSliding = false;
            
        }

    }

    void WallJumpingTime(){
        wallJumping = false;
    }

    // Dashing
    void Dash(float x, float y){

        if(Input.GetKeyDown("q") && canDash && !PauseMenu.isPaused){
            
            
            dashFX.Play();
            ShakeCamera();
            SoundManager.PlaySound("dashSFX");
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

        if(x > 0 && !facingRight){
            facingRight = true;
            transform.Rotate(0f, 180f, 0f);
            walkFX.Play();


        }else if(x < 0 && facingRight){
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
    

    void OnTriggerEnter2D(Collider2D col){
        
        if(col.gameObject.tag == "Lava"){
            deathFX.Play();
            transform.position = respawnPoint;
            SoundManager.PlaySound("deathSFX");
            ShakeCamera();
            


        }else if(col.gameObject.tag == "Checkpoint"){
            respawnPoint = transform.position;
        }

    }

}
