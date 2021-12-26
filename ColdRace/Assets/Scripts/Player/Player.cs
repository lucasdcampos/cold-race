using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Other scripts:
    public Movement move;
    public Collision coll;
    public AnimationController anim;



    public bool isDead;
    public Vector3 respawnPoint;


    //Player Inventory:
    public int cake;

    void Start()
    {
        isDead = false;
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
