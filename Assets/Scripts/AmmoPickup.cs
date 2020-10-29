using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] Guns _gunAmmo;
    [SerializeField] int _ammoAmount = 20;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.GetComponent<PlayerController>().GainAmmo(_gunAmmo, _ammoAmount);
        }
    }
}
