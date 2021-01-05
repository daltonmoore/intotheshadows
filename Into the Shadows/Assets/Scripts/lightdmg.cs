using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class lightdmg : MonoBehaviour
{
    player player;
    Light2D light2D;
    bool lightOn;
    Coroutine lightTimerCoroutine;
    float lightTimer = 2f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        light2D = GetComponent<Light2D>();
    }

    private void Update()
    {
        if (lightTimerCoroutine == null)
        {
            lightTimerCoroutine = StartCoroutine(LightTimer());
        }
    }

    IEnumerator LightTimer()
    {
        yield return new WaitForSeconds(lightTimer);
        lightOn = !lightOn;
       // light2D.
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
