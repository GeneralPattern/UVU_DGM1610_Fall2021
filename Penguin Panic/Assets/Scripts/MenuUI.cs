using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuUI : MonoBehaviour
{
    //plays game by pressing the button
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Game");

    }
    //quits game by pressing the button
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
