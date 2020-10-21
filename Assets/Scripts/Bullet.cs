using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    [SerializeField] int _damage = 20;
    [SerializeField] float _timer = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
        _timer -= Time.deltaTime;
        if(_timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        if(other.gameObject.tag.Equals("Player") || other.gameObject.tag.Equals("Enemy"))
        {
            other.gameObject.GetComponent<Health>().TakeDamge(_damage);
        }
    }
}
