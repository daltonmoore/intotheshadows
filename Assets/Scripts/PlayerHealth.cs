using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public HealthBar healthBar;

    public override void Start()
    {
        base.Start();
        healthBar.SetMaxHealth(maxHealth);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        healthBar.SetHealth(currentHealth);
    }

}
