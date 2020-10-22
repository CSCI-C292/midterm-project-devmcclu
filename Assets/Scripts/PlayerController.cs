using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _mouseSensitivity = 10f;
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] Inventory _inventory;
    CharacterController _characterController;
    GunController _gunController;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _gunController = GetComponentInChildren<GunController>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Movement();

        if(Input.GetButton("Fire1") && _inventory.Ammo[(int) _inventory.CurrentGun] > 0)
        {
            if (_gunController.Shoot())
            {
                _inventory.Ammo[(int) _inventory.CurrentGun] -= 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapon(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeapon(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeWeapon(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeWeapon(3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            ChangeWeapon(4);
        }
    }

    void Aim()
    {
        float mouseX = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.up, mouseX * _mouseSensitivity);
    }

    void Movement()
    {
        Vector3 horVector = transform.right * Input.GetAxis("Horizontal");
        Vector3 verVector = transform.forward * Input.GetAxis("Vertical");
        Vector3 movementVector = horVector + verVector;

        _characterController.Move(movementVector * _moveSpeed * Time.deltaTime);

    }

    void ChangeWeapon(int weapon)
    {
        if(_inventory.HaveGun[weapon])
        {
            switch (weapon)
            {
                case 0:
                    _inventory.CurrentGun = Inventory.Guns.Knife;
                    break;
                case 1:
                    _inventory.CurrentGun = Inventory.Guns.Pistol;
                    break;
                case 2:
                    _inventory.CurrentGun = Inventory.Guns.Shotgun;
                    break;
                case 3:
                    _inventory.CurrentGun = Inventory.Guns.Rifle;
                    break;
                case 4:
                    _inventory.CurrentGun = Inventory.Guns.RocketLauncher;
                    break;
            }
            _gunController.ChangeBullet(_inventory.AmmoPrefab[weapon]);
        }
    }
}
