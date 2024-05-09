using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Action that occurs when the Play button is hit.
    public void Play() {
        //TODO: Implement this so that the screen fades to black, random generation happens, and the player is transported to the SPECIFIC built level (not just the next!)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Action that occurs when the Quit button is hit.
    public void Quit() {
        //TODO: Add fade to black, ensure no mem leaks!
        Application.Quit();
    }
}
