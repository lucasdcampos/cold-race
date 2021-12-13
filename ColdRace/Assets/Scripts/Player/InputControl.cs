using UnityEngine;
using System.Collections;

public class InputControl : MonoBehaviour
{
    public int Xbox_One_Controller = 0;
    public int PS4_Controller = 0;
    public int keyboard = 0;

    public void Update()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            if (names[x].Length == 19)
            {
                PS4_Controller = 1;
                Xbox_One_Controller = 0;
                keyboard = 0;
            }
            else if (names[x].Length == 33)
            {
                //set a controller bool to true
                PS4_Controller = 0;
                Xbox_One_Controller = 1;
                keyboard = 0;

            }
            else
            {
                keyboard = 1;
                PS4_Controller = 0;
                Xbox_One_Controller = 0;
            }
        }


        if (Xbox_One_Controller == 1)
        {
            //do something
        }
        else if (PS4_Controller == 1)
        {
            //do something
        }
        else
        {
            
        }
    }
}