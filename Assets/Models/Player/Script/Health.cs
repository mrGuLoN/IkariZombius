using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float  _currentHealth;
        

    public void Damage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Debug.Log("Dead");
        }
    }

    public void UpdateData(float maxHealth)
    {
        _currentHealth = maxHealth;       
    }
}
