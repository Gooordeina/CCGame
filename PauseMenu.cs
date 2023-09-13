using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    void Start()
    {
    //Time is runninf as the game starts
        Time.timeScale = 1f;
    }
    //create variables and assets
    public bool GameIsPaused = false;
    public GameObject Player;
    public GameObject Countdown;

    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        //linking this script with the playermovement script and the countdowntimer script
        PlayerMovement Script = Player.GetComponent<PlayerMovement>();
        CountdownTimer Script2 = Countdown.GetComponent<CountdownTimer>();

        //game pausing function. game is paused in these three situations - pausemenu, losepanel, or winpanel pops out.
        if (Input.GetKeyDown(KeyCode.Escape) && Script.count != 3 && Script2.currentTime != 0)
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    //game resume function. game resumes after pressing the resume button on he pause menu, enable the mouse cursor at the same time.
    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //game pause function. game pauses after pressing the escape key during the game, disable the mouse cursor at the same time.
    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    //load main menu function. go back to main menu after pressing the main menu key on the pause menu
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    //quit game funcion. quit game after pressing quit button on the pause menu
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
