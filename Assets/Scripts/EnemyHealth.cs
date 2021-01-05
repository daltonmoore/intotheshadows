using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    // Start is called before the first frame update
    public void SetMaxHealth(int health)
    {
        base.Start();
    }

    // Update is called once per frame
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
