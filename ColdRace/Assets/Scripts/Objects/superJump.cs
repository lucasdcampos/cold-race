using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superJump : MonoBehaviour
{

    public float superJumpSpeed;

    private void OnTriggerEnter2D(Collider2D col) {

        if(col.CompareTag("Player"))
        {
            col.attachedRigidbody.velocity = new Vector2(col.attachedRigidbody.velocity.x, superJumpSpeed);
        }
        

    }
}
