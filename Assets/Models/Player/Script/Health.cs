using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{ 
   
    private float _currentHealth;

    public delegate void HealthHud(float health);
    public static event HealthHud _healthHud;

    private void Start()
    {
        _healthHud(100f);
    }

    public void Damage(float damage)
    {        
        _currentHealth -= damage;
        _healthHud(_currentHealth);
        if (_currentHealth <= 0)
        {           
            _healthHud(0);
        }
    }

    public void UpdateData(float maxHealth)
    {
        _currentHealth = maxHealth;       
    }

    public void HealthUp(int health)
    {
        _currentHealth += health;
        if (_currentHealth > 100) _currentHealth = 100;
        _healthHud(_currentHealth);
    }
}
