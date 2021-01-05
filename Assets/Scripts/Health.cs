using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;

    // Start is called before the first frame update
    public virtual void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
