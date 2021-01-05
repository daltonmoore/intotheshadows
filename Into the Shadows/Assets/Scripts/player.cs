using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public bool inLight;
    int totalHealth;
    int health = 1000;
    float lightDmgCoolDown = .01f;
    Coroutine lightDmgCoolDownCoroutine;
    Canvas canvas;
    Slider healthBar;

    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        healthBar = canvas.transform.Find("Healthbar").GetComponent<Slider>();
        healthBar.maxValue = 
            totalHealth = health;
        healthBar.value = healthBar.maxValue;
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        transform.position += new Vector3(x * .01f, y * .01f);

        if (inLight && lightDmgCoolDownCoroutine == null)
        {
            HitByLight();
            lightDmgCoolDownCoroutine = StartCoroutine(LightDmgCoolDown());
        }
    }

    IEnumerator LightDmgCoolDown()
    {
        yield return new WaitForSeconds(lightDmgCoolDown);
        lightDmgCoolDownCoroutine = null;
    }

    public void HitByLight()
    {
        health--;
        healthBar.value = (float)health / totalHealth * totalHealth;
    }
}
