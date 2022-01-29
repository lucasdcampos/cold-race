using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashReset : MonoBehaviour
{
    public Player player;
    public GameObject sprite;

    public float cooldown = 3f;

    void Update()
    {
        if (player.isDead)
        {
            gameObject.SetActive(true);
        }
    }




    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && sprite.activeSelf)
        {
            player.move.canDash = true;
            sprite.SetActive(false);
            StartCoroutine(StartCounter());

        }
    }




    IEnumerator StartCounter()
    {
        yield return new WaitForSeconds(cooldown);
        
        sprite.SetActive(true);
        //Turn the Game Oject back off after 1 sec.
        yield return new WaitForSeconds(1);
        StopCoroutine(StartCounter());
    }



}
