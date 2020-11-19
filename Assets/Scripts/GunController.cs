using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] float _gunTimer;
    [SerializeField] float _currentTime;
    [SerializeField] AudioSource _audioSource;

    void Update()
    {
        _currentTime += Time.deltaTime;
    }

    public bool Shoot()
    {
        //Create a bullet if the timer is correct
        if (_currentTime >= _gunTimer)
        {
            GameObject newBullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            newBullet.transform.forward = Camera.main.transform.forward;
            _currentTime = 0f;
            _audioSource.Play();
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

    public void ChangeAudioClip(AudioClip clip)
    {
        _audioSource.clip = clip;
    }
}
