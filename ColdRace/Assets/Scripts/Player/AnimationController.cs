using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public Animator camAnim;
    public Animator anim;
    public Player player;

    public bool isDancing = false;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        


    }

    // Update is called once per frame
    void Update()
    {

        anim.SetBool("isSliding", player.move.wallSliding || player.move.wallClimbing && player.move.isOnWall);
        anim.SetBool("isJumping", !player.move.isGrounded && !player.move.wallSliding && !player.move.wallClimbing);
        anim.SetBool("isLanding", player.move.isLanding);
        anim.SetBool("isDancing", isDancing);
        camAnim.SetBool("isDead", player.isDead);

        if (player.move.isGrounded && !player.move.wallClimbing && player.move.rb.velocity.x != 0) {
            anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        }



        if(Input.GetKeyDown("b")){
            isDancing = !isDancing;
        }
    }





}
