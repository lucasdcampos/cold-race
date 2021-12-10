using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string scene;

    public void ChangeS(){
        SceneManager.LoadScene(scene);

    }

    public void OnApplicationQuit(){
        Application.Quit();
    }
}