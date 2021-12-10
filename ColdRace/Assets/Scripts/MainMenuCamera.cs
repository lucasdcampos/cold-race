using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    public Rigidbody2D rb;
    public float camSpeed;
    
    void Start()
    {
        rb.velocity = new Vector2(camSpeed, rb.velocity.y);
    }
}
