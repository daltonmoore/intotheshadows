using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransferTrigger : MonoBehaviour
{
    public string levelOneScene;
    public string villageScene;
    public string winScene;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "ScottsTestScene":
                    SceneManager.LoadScene(villageScene);
                    break;
                case "HUB"://villageScene
                    SceneManager.LoadScene(winScene);
                    break;
            }
        }
    }
}
