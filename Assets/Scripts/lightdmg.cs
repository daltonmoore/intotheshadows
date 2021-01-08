using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class lightdmg : MonoBehaviour
{
    player player;
    Light2D light2D;
    BoxCollider2D boxCollider;
    bool lightOn = true;
    Coroutine lightTimerCoroutine;

    [SerializeField]
    float lightTimer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        light2D = GetComponent<Light2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (lightTimerCoroutine == null && lightTimer != 0)
        {
            lightTimerCoroutine = StartCoroutine(LightTimer());
        }
    }

    IEnumerator LightTimer()
    {
        yield return new WaitForSeconds(lightTimer);
        lightOn = !lightOn;
        light2D.enabled = lightOn;
        lightTimerCoroutine = null;
        boxCollider.isTrigger = lightOn;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && lightOn)
        {
            Debug.Log("Damage");
            player.inDamageLight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.inDamageLight = false;
        }
    }
}
