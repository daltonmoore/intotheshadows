using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{

    public static bool GamePaused = false;

    public GameObject pauseMenuUI;

    public SceneClass sceneClass;


    void Start()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (GamePaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Resume the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    // Pause the game
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    //public void SaveGame()
    //{

    //}

    // Quit game and go back to main menu
    public void QuitToMenu()
    {
        sceneClass.MainMenu();
    }
}
