using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>(); ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.inLight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.inLight = false;
        }
    }
}
