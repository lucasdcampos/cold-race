using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashReset : MonoBehaviour
{
    public Player player;
    public GameObject sprite;



    void Update()
    {
        if (player.isDead)
        {
            gameObject.SetActive(true);
        }
    }








    public void OnCollisionEnter2D(Collision2D col)
    {



    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && sprite.activeSelf)
        {
            FindObjectOfType<SoundManager>().Play("dashreset");
            player.move.canDash = true;
            sprite.SetActive(false);
            StartCoroutine(StartCounter());

        }
    }




    IEnumerator StartCounter()
    {
        yield return new WaitForSeconds(5);

        sprite.SetActive(true);
        //Turn the Game Oject back off after 1 sec.
        yield return new WaitForSeconds(1);
        StopCoroutine(StartCounter());
    }



}
