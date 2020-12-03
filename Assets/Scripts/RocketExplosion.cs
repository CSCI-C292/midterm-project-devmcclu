using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{
    [SerializeField] GameObject _explosion;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag.Equals("Enemy"))
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);        }
    }
}
