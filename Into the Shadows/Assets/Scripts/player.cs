using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public bool inLight, inHealingLight;
    [SerializeField]
    int totalHealth;
    int health;
    float lightDmgCoolDown = .01f;
    float lightHealCoolDown = .02f;
    Coroutine lightDmgCoolDownCoroutine, lightHealCoolDownCoroutine;
    Canvas canvas;
    Slider healthBar;

    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        healthBar = canvas.transform.Find("Healthbar").GetComponent<Slider>();
        health = totalHealth;
        healthBar.maxValue = totalHealth;
        healthBar.value = healthBar.maxValue;
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        transform.position += new Vector3(x * .01f, y * .01f);

        if (inLight && lightDmgCoolDownCoroutine == null)
        {
            HitByDmgLight();
            lightDmgCoolDownCoroutine = StartCoroutine(LightDmgCoolDown());
        }

        if (inHealingLight && lightHealCoolDownCoroutine == null)
        {
            HitByHealLight();
            lightHealCoolDownCoroutine = StartCoroutine(LightHealCoolDown());
        }
    }

    IEnumerator LightDmgCoolDown()
    {
        yield return new WaitForSeconds(lightDmgCoolDown);
        lightDmgCoolDownCoroutine = null;
    }

    IEnumerator LightHealCoolDown ()
    {
        yield return new WaitForSeconds(lightHealCoolDown);
        lightHealCoolDownCoroutine = null;
    }

    public void HitByDmgLight()
    {
        if (health > 0)
        {
            health--;
            healthBar.value = (float)health / totalHealth * totalHealth;
        }
    }

    public void HitByHealLight()
    {
        if (health < totalHealth)
        {
            health++;
            healthBar.value = (float)health / totalHealth * totalHealth;
        }
    }
}
