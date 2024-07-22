using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
* This program handles logic related to the main menu.
* 
* The current two scenes are defined by the following indexes:
* 0: Main Menu
* 1: Game Scene
* 
* These methods are then called on the related buttons.
* All these methods are self explainitory.
*
*/
public class NewBehaviourScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
    public void QuitApp()
    {
        Application.Quit();
    }

    /*
     *  Android applications require a specifc way to quit the application.
     *  The code below is intended to move the application to the back if the activities.
     *  Doesn't work currently.
     */
    public static void MoveAndroidApplicationToBack()
    {
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
    }

}
