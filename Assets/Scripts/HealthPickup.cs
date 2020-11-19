using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int _healthAmount = 20;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Health");
            Destroy(gameObject);
            other.GetComponent<Health>().GainHealth(_healthAmount);
        }
    }
}
