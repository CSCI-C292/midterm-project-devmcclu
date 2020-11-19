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
            switch (_gunAmmo)
            {
                case Guns.Pistol:
                    FindObjectOfType<AudioManager>().Play("PistolAmmo");
                    break;
                case Guns.Rifle:
                    FindObjectOfType<AudioManager>().Play("RifleAmmo");
                    break;
                case Guns.RocketLauncher:
                    FindObjectOfType<AudioManager>().Play("RocketAmmo");
                    break;
                case Guns.Shotgun:
                    FindObjectOfType<AudioManager>().Play("ShotgunAmmo");
                    break;
            }
            Destroy(gameObject);
            other.GetComponent<PlayerController>().GainAmmo(_gunAmmo, _ammoAmount);
        }
    }
}
