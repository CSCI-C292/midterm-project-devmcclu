using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] GameObject _bullet;

    public void Shoot()
    {
        GameObject newBullet = Instantiate(_bullet, transform.position, Quaternion.identity);
        newBullet.transform.forward = Camera.main.transform.forward;
    }
}
