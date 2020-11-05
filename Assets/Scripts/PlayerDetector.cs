using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] EnemyController _enemyController;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _enemyController.SetPlayerObject(other.gameObject);
        }
    }
}
