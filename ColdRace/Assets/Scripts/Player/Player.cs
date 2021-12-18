using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Other scripts:
    public Movement move;
    public Collision coll;
    public AnimationController anim;
    public Tutorial tutorial;
    public Dialogue dialogue;


    //Level Manager:
    public bool tutorialJump;
    public bool tutorialClimb;
    public bool tutorialDash;




    public int cake;

    public Vector3 respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
