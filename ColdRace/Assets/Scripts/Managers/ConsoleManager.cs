using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleManager : MonoBehaviour
{

    [HideInInspector] public bool consoleActive;
    [HideInInspector] public string input;

    [Header("Console Properties:")]
    
    public float y = 2010f;
    public float boxHeigth = 150f;
    public int fontSize = 50;


    void Update(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            consoleActive = !consoleActive;
        }
    }


     private void OnGUI() {
        
        if(!consoleActive){ 
            return;
        }

        //Creating Console Box
        GUI.Box(new Rect(0, Screen.height - boxHeigth, Screen.width, boxHeigth), "");
        GUI.backgroundColor = new Color(0,0,0,0);
        input = GUI.TextField(new Rect(40f, Screen.height - boxHeigth + 10f, Screen.width - 20f, boxHeigth), input);

        //Stylizing Console Box

        GUI.skin.textField.fontSize = fontSize;
        GUI.skin.label.fontSize = fontSize;
        GUI.contentColor = new Color(0, 254, 0, 100);

        GUI.Label(new Rect(10, Screen.height - boxHeigth + 10, Screen.width, boxHeigth), ">");
        
        

    }

}
