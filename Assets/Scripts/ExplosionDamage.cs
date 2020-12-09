using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    
    [SerializeField] int _damage = 20;
    [SerializeField] ParticleSystem _particle;

    private void Awake()
    {
        Destroy(gameObject, _particle.main.duration);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Enemy"))
        {
            other.gameObject.GetComponent<Health>().TakeDamge(_damage);
        }
    }
}
