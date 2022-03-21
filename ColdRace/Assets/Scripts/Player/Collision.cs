using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public Player player;

    void Start()
    {
        
        player.move = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.move.isGrounded)
        {
            player.isDead = false;
        }
    }


    void OnTriggerEnter2D(Collider2D col){
        
        if(col.gameObject.tag == "Lava"){
            player.move.deathFX.Play();
            FindObjectOfType<SoundManager>().Play("death");
            transform.position = player.respawnPoint;
            player.isDead = true;
            player.move.ShakeCamera();
            


        }else if(col.gameObject.tag == "Checkpoint"){
            player.respawnPoint = transform.position;

        }


        if(col.gameObject.tag == "DashReset")
        {
            player.move.canDash = true;
            FindObjectOfType<SoundManager>().Play("dash_reset");
        }

        if(col.gameObject.tag == "SuperJump"){
            player.move.ShakeCamera();
            FindObjectOfType<SoundManager>().Play("superjump");
        }


    }

    void OnTriggerExit2D(Collider2D collision)
    {
        player.isDead = false;
    }




}
