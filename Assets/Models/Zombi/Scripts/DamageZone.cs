using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public EnemyHealth _enemyHealth;

    public void Damage(float damage)
    {
        _enemyHealth.TakeDamage(damage);
    }
}
