using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Player player;
    public bool hasJumped;
    public bool hasDashed;
    public bool hasSlided;

    public GameObject jumpText;
    public GameObject dashText;
    public GameObject slideText;




    public void JumpTutorial()
    {
        if (!hasJumped)
        {
            jumpText.SetActive(true);
            if (Input.GetButtonDown("Jump"))
            {
                hasJumped = true;
                jumpText.SetActive(false);

            }
        }
    }



   public void DashTutorial()
    {
        if (!hasDashed)
        {
            dashText.SetActive(true);
            if (Input.GetButtonDown("Dash"))
            {
                hasDashed = true;
                dashText.SetActive(false);

            }
        }

    }


   public void SlideTutorial()
    {
        if (!hasSlided)
        {
            slideText.SetActive(true);
            if (player.move.isOnWall && Input.GetKey("e"))
            {
                slideText.SetActive(false);
                hasSlided = true;
            }

        }
    }


}
