using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public SceneClass sceneClass;

    public void PlayGame()
    {
        sceneClass.GoToLevelT();
    }

    public void QuitGame()
    {
        Debug.Log("The game is quitting.");
        Application.Quit();
    }

    public void GameOptions()
    {
        sceneClass.Options();
    }

    public void GameCredits()
    {
        sceneClass.Credits();
    }

}
