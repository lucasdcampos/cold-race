using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBall : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedX;
    public float speedY;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speedX, speedY);
        StartCoroutine(InvertSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartCoroutine(){
        StartCoroutine(InvertSpeed());
    }

        private IEnumerator InvertSpeed()
    {
        yield return new WaitForSeconds(time);
        if(rb.velocity.x > 0 || rb.velocity.y > 0){
            rb.velocity = new Vector2(speedX * -1, speedY * -1);
        }else{
            rb.velocity = new Vector2(speedX * 1, speedY * 1);
        }
        StartCoroutine();

    }

}
