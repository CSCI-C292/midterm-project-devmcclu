using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _health = 100;
    [SerializeField] int _maxHealth = 100;
    [SerializeField] int _armor = 0;
    [SerializeField] int _maxArmor = 100;

    public void TakeDamge(int value)
    {
        if (_armor > 0)
        {
            _health -= value / 2;
            _armor -= value / 2;
        }
        else
        {
            _health -= value;
        }

        if (_health <= 0)
        {
            if(gameObject.CompareTag("Player"))
            {
                GameEvents.InvokePlayerDied();
            }
            else if (gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);            
            }
        }
    }

    public void GainHealth(int value)
    {
        if(_health + value <= _maxHealth)
        {
            _health += value;
        }
        else
        {
            _health = _maxHealth;
        }
    }

    public void GainArmor(int value)
    {
        if(_armor + value <= _maxArmor)
        {
            _armor += value;
        }
        else
        {
            _health = _maxArmor;
        }
    }
}
