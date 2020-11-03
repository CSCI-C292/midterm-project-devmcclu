using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] float _gunTimer;
    [SerializeField] float _currentTime;

    void Update()
    {
        _currentTime += Time.deltaTime;
    }

    public bool Shoot()
    {
        if (_currentTime >= _gunTimer)
        {
            GameObject newBullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            newBullet.transform.forward = Camera.main.transform.forward;
            _currentTime = 0f;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeBullet(GameObject ammo)
    {
        _bullet = ammo;
    }

    public void ChangeTimer(float time)
    {
        _gunTimer = time;
    }
}
