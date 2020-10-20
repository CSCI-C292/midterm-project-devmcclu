using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int armor = 0;

    public void TakeDamge(int value)
    {
        if (armor > 0)
        {
            health -= value / 2;
            armor -= value / 2;
        }
        else
        {
            health -= value;
        }
    }
}
