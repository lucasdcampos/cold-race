using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{


    public Animator anim;
    public Movement move;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Movement>();
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        
        anim.SetBool("isSliding", move.wallSliding || move.wallClimbing);
        anim.SetBool("isJumping", !move.isGrounded && !move.wallSliding && !move.wallClimbing);

        if(move.isGrounded && !move.wallClimbing && move.rb.velocity.x != 0){
            anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        }

    }



}
