using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] int _health = 100;
    [SerializeField] int _maxHealth = 100;
    [SerializeField] int _armor = 0;
    [SerializeField] int _maxArmor = 100;
    [SerializeField] bool _isPlayer = false;
    [SerializeField] TextMeshProUGUI _healthText;
    [SerializeField] TextMeshProUGUI _armorText;

    void Start()
    {
        if(_isPlayer)
            UpdateText();
    }    

    void UpdateText()
    {
        _healthText.text = string.Concat("Health: ", _health.ToString());
        _armorText.text = string.Concat("Armor: ", _armor.ToString());
    }

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

        if(gameObject.CompareTag("Player"))
        {
            UpdateText();
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

        if(gameObject.CompareTag("Player"))
        {
            UpdateText();
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

        if(gameObject.CompareTag("Player"))
        {
            UpdateText();
        }
    }
}
