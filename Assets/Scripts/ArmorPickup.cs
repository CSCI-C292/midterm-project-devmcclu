using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickup : MonoBehaviour
{
    [SerializeField] int _armorAmount = 20;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Armor");
            Destroy(gameObject);
            other.GetComponent<Health>().GainArmor(_armorAmount);
        }
    }
}
