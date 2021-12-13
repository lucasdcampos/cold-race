using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public Movement move;
    public Player player;

    void Start()
    {
        
        move = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col){
        
        if(col.gameObject.tag == "Lava"){
            move.deathFX.Play();
            FindObjectOfType<SoundManager>().Play("death");
            transform.position = player.respawnPoint;
            move.ShakeCamera();
            


        }else if(col.gameObject.tag == "Checkpoint"){
            player.respawnPoint = transform.position;
        }


    }


    void OnTriggerStay2D(Collider2D col)
    {


        if (col.gameObject.name == "Jump")
        {
            player.tutorial.JumpTutorial();

        }

        if (col.gameObject.name == "Dash")
        {
            player.tutorial.DashTutorial();
        }

        if (col.gameObject.name == "Slide")
        {
            player.tutorial.SlideTutorial();
        }


    }


    private void OnTriggerExit2D(Collider2D col)
    {
        player.tutorial.QuitTutorial();
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.layer == 10){
            player.move.isJumping = false;
            player.move.canDash = true;
        }





        // MISSIONS:


    }
}
