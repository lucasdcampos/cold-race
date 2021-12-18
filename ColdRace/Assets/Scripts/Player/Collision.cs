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











    
}
