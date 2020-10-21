using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _health = 100;
    [SerializeField] int _armor = 0;

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
            Destroy(gameObject);
        }
    }
}
