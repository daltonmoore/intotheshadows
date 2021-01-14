using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPortal : MonoBehaviour
{

    public SceneClass sceneClass;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //colliding object is player
        if (collision.tag == "Player")
        {
            //triggered = true;
            Debug.Log("Portal Time");
            sceneClass.GoToHub();
        }
    }
}
