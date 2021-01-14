using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public SceneClass sceneClass;

    public void BackBttn()
    {
        SceneManager.UnloadSceneAsync("Options");
    }
}
