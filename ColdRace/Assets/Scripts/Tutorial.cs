using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Player player;
    public bool hasJumped;
    public bool hasDashed;
    public bool hasSlided;
    [Space]
    public GameObject jumpText;
    public GameObject dashText;
    public GameObject slideText;
    [Space]
    public InputControl input;
    public GameObject PS4_X;
    public GameObject PS4_R1;
    public GameObject PS4_L2;


    [Space]
    public GameObject KEYBOARD_SPACE;
    public GameObject KEYBOARD_Q;
    public GameObject KEYBOARD_E;
    [Space]
    public GameObject XBOX_LT;
    public GameObject XBOX_A;
    public GameObject XBOX_RB;



    public void JumpTutorial()
    {
        if (!hasJumped)
        {
            if(input.keyboard == 1)
            {
                KEYBOARD_SPACE.SetActive(true);
                PS4_X.SetActive(false);
                //XBOX_A.SetActive(false);

            }else if(input.PS4_Controller == 1)
            {
                PS4_X.SetActive(true);
                KEYBOARD_SPACE.SetActive(false);
            }



            jumpText.SetActive(true);
            if (Input.GetButtonDown("Jump") && player.move.isGrounded)
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


            if (input.keyboard == 1)
            {
                KEYBOARD_Q.SetActive(true);
                PS4_R1.SetActive(false);

            }
            else if (input.PS4_Controller == 1)
            {
                PS4_R1.SetActive(true);
                KEYBOARD_Q.SetActive(false);
            }
            dashText.SetActive(true);

            if (input.keyboard == 1)
            {

            }
            
            if (Input.GetButtonDown("Dash") && player.move.canDash)
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

            if (input.keyboard == 1)
            {
                KEYBOARD_E.SetActive(true);
                PS4_L2.SetActive(false);

            }
            else if (input.PS4_Controller == 1)
            {
                PS4_L2.SetActive(true);
                KEYBOARD_E.SetActive(false);
            }
            slideText.SetActive(true);

            if (player.move.isOnWall && Input.GetButton("Climb"))
            {
                slideText.SetActive(false);
                hasSlided = true;
            }

        }
    }


    public void QuitTutorial()
    {
        slideText.SetActive(false);
        dashText.SetActive(false);
        jumpText.SetActive(false);
    }


}
