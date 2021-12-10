using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static AudioSource audio;


    // Musics:
    public static AudioClip pianoMood5;
    public static AudioClip MainTheme;
    public static AudioClip snowfallFinal;

    // Sound Effects:
    public static AudioClip dashSFX;
    public static AudioClip deathSFX;

    void Start(){

        audio = GetComponent<AudioSource>();

        // Musics:
        MainTheme = Resources.Load<AudioClip>("MainTheme");
        pianoMood5 = Resources.Load<AudioClip>("pianoMood5");
        pianoMood5 = Resources.Load<AudioClip>("snowfallFinal");


        // Sound Effects:
        dashSFX = Resources.Load<AudioClip>("dashSFX");
        deathSFX = Resources.Load<AudioClip>("deathSFX");


    }


    public static void PlaySound(string clip){

        switch(clip){
            //Musics:
            case "MainTheme":
            audio.PlayOneShot(MainTheme);
            break;

            case "pianoMood5":
            audio.PlayOneShot(pianoMood5);
            break;
            
            case "snowfallFinal":
            audio.PlayOneShot(snowfallFinal);
            break;

            //Sound Effects:
            case "dashSFX":
            audio.PlayOneShot(dashSFX);
            break;

            case "deathSFX":
            audio.PlayOneShot(deathSFX);
            break;

        }
    }





}
