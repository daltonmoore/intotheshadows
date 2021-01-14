using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SceneClass
{

    //Go to the Hub
    public void GoToHub()
    {
        Debug.Log("Going to Hub");
        SceneManager.LoadScene("HUB");
    }

    //Go to Tutorial Level
    public void GoToLevelT()
    {
        Debug.Log("Going to Tutorial Level");
        SceneManager.LoadScene("Tutorial_Level");
    }

    //Go to First Level
    public void GoToLevel1()
    {
        Debug.Log("Going to Level One");
        //SceneManager.LoadScene("HUB");
    }

    //Go to Second Level
    public void GoToLevel2()
    {
        Debug.Log("Going to Level Two");
        //SceneManager.LoadScene("HUB");
    }

    //Go to Third Level
    public void GoToLevel3()
    {
        Debug.Log("Going to Level 3");
        //SceneManager.LoadScene("HUB");
    }

    //Go to Fourth Level
    public void GoToLevel4()
    {
        Debug.Log("Going to Level Four");
        //SceneManager.LoadScene("HUB");
    }

    //Go to Fifth Level
    public void GoToLevel5()
    {
        Debug.Log("Going to Level Five");
        //SceneManager.LoadScene("HUB");
    }

    //Go to Sixth Level
    public void GoToLevel6()
    {
        Debug.Log("Going to Level Six");
        //SceneManager.LoadScene("HUB");
    }

    public void MainMenu()
    {
        Debug.Log("Going to Main Menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        Debug.Log("Settings Mode");
        SceneManager.LoadScene("Options", LoadSceneMode.Additive);
        
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Options"));

    }

    public void Credits()
    {
        Debug.Log("Roll the Credits");
        SceneManager.LoadScene("Credits");
    }

}
