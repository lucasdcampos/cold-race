using UnityEngine;
using System.Collections;

public class InputControl : MonoBehaviour
{

    //Devices
    public bool xbox;
    public bool dualshock;
    public bool keyboard;

    //Inputs
    public bool jumpDown;
    public bool jumpUp;
    public bool jump;


    public bool dashDown;
    public bool dashUp;
    public bool dash;

    public bool climbDown;
    public bool climbUp;
    public bool climb;

    public void Update()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            if (names[x].Length == 19)
            {
                dualshock = true;
            }
            else if (names[x].Length == 33)
            {
                xbox = true;

            }
            else
            {
                keyboard = true;

            }
        }


        if (xbox)
        {
            keyboard = false;
            dualshock = false;
        }
        else if (dualshock)
        {
            xbox = false;
            keyboard = false;
        }
        else if (keyboard)
        {
            xbox = false;
            keyboard = false;
        }
    }





    public void Inputs()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpDown = true;
        }
    }




}






