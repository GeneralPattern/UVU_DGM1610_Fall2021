using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [Header("HUD")]
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI ammoText;

    [Header("Pause Menu")]
    public GameObject pauseMenu;

    public GameObject pauseMenu2;

    public GameObject pauseMenu3;
    [Header("End Game Screen")]
    

    public GameObject endGameScreen;

    //Instance
    public static GameUI instance;

    void Awake()
    {
        instance = this;
    }

    public void UpdateAmmoText(int curAmmo, int maxAmmo)
    {
        ammoText.text = "Ammo: " + curAmmo + " / " + maxAmmo; 
    }

    public void  UpdateScoreText (int score)
    {
        scoreText.text = "Score: " + score;

    }
    public void TogglePauseMenu (bool paused)
    {
        pauseMenu.SetActive(paused);
    }

    public void TogglePauseMenu2 (bool paused)
    {
        pauseMenu2.SetActive(paused);
    }

    public void TogglePauseMenu3 (bool paused)
    {
        pauseMenu3.SetActive(paused);
    }
 
    public void OnResumeButton()
    {
        GameManager.instance.TogglePauseGame();
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene("Game");        
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
