using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static bool isPaused;
    public string scene;

    void Start(){
        
        isPaused = false;
    }

    void Update(){

        if(Input.GetKeyDown(KeyCode.Escape)){

            if(isPaused){
                Resume();
            }else{
                Pause();
            }

        }

    }


    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        
    }

    public void Resume() 
    { 
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Home() 
    { 
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit () {
        Application.Quit();
    }

    public void Scene () {
        SceneManager.LoadScene(scene);
    }
}