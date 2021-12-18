using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{


    public Animator anim;
    public Player player;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        
        anim.SetBool("isSliding", player.move.wallSliding || player.move.wallClimbing || player.move.isOnWall);
        anim.SetBool("isJumping", !player.move.isGrounded && !player.move.wallSliding && !player.move.wallClimbing);

        if(player.move.isGrounded && !player.move.wallClimbing && player.move.rb.velocity.x != 0){
            anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        }

    }



}
