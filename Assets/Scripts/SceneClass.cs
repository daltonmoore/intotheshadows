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
        Debug.Log("Going to hub");
        //SceneManager.LoadScene("HUB");
    }

}
