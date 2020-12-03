using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    
    [SerializeField] int _damage = 20;
    [SerializeField] float _timer = 2f;

    void Update()
    {
        if(_timer <= 0)
        {
            Destroy(gameObject);
        }    
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(other.gameObject.tag.Equals("Player") || other.gameObject.tag.Equals("Enemy"))
        {
            other.gameObject.GetComponent<Health>().TakeDamge(_damage);
        }
    }
}
