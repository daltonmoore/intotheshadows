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

}
