using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int curScore;
    public bool gamePaused;
    public bool gamePaused3;
    

    //Instance
    public static GameManager instance;

    void Awake()
    {
        instance = this;

    }

    void Start()
    {
        Time.timeScale = 1.0f; 

    }

    void Update()
    {
        //Brings up pause menu upon pressing cancel
        if(Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
     
    }

    
    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        //pause menu toggle
        GameUI.instance.TogglePauseMenu(gamePaused);
        Cursor.lockState = gamePaused == true ?  CursorLockMode.None : CursorLockMode.Locked;

    }


    public void AddScore(int score)
    {
        //adds score to UI
        curScore += score;

        GameUI.instance.UpdateScoreText(curScore);

        if(curScore >= scoreToWin)
            ToggleEndWin();

    }

    public void ToggleEndWin()
    {
        gamePaused3 = !gamePaused3;
        Time.timeScale = gamePaused3 == true ? 0.0f : 1.0f;

        //pause menu toggle
        GameUI.instance.TogglePauseMenu3(gamePaused3);
        Cursor.lockState = gamePaused3 == true ?  CursorLockMode.None : CursorLockMode.Locked;

    }

    
        

}
