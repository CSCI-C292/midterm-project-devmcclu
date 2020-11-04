using System;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _mouseSensitivity = 10f;
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] bool _canMove = true;

    [SerializeField] Inventory _inventory;
    [SerializeField] TextMeshProUGUI _ammoText;
    [SerializeField] GameObject[] _gunObjects = new GameObject[5];
    GameObject _currentGun;
    CharacterController _characterController;
    GunController _gunController;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        GameEvents.LevelFinished += OnLevelEnd;
        GameEvents.PlayerDied += Death;
    }

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _gunController = GetComponentInChildren<GunController>();
        _currentGun = _gunObjects[1];
        UpdateAmmoText();
    }

    // Update is called once per frame
    void Update()
    {
        if(_canMove)
        {
            Aim();
            Movement();

            if(Input.GetButton("Fire1") && _inventory.Ammo[(int) _inventory.CurrentGun] > 0)
            {
                if (_gunController.Shoot())
                {
                    _inventory.Ammo[(int) _inventory.CurrentGun] -= 1;
                    UpdateAmmoText();
                }
            }

            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeWeapon(Guns.Knife);
            }
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeWeapon(Guns.Pistol);
            }
            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                ChangeWeapon(Guns.Shotgun);
            }
            if(Input.GetKeyDown(KeyCode.Alpha4))
            {
                ChangeWeapon(Guns.Rifle);
            }
            if(Input.GetKeyDown(KeyCode.Alpha5))
            {
                ChangeWeapon(Guns.RocketLauncher);
            }
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

    void ChangeWeapon(Guns weapon)
    {
        if(_inventory.HaveGun[(int) weapon])
        {
            switch (weapon)
            {
                case Guns.Knife:
                    _inventory.CurrentGun = Guns.Knife;
                    break;
                case Guns.Pistol:
                    _inventory.CurrentGun = Guns.Pistol;
                    break;
                case Guns.Shotgun:
                    _inventory.CurrentGun = Guns.Shotgun;
                    break;
                case Guns.Rifle:
                    _inventory.CurrentGun = Guns.Rifle;
                    break;
                case Guns.RocketLauncher:
                    _inventory.CurrentGun = Guns.RocketLauncher;
                    break;
            }
            
            _gunController.ChangeBullet(_inventory.AmmoPrefab[(int) weapon]);
            _gunController.ChangeTimer(_inventory.FireTimer[(int) weapon]);
            
            _currentGun.SetActive(false);
            _currentGun = _gunObjects[(int) weapon];
            _currentGun.SetActive(true);
            
            UpdateAmmoText();
        }
    }

    void OnLevelEnd(object sender, EventArgs args)
    {
        _canMove = false;
    }
    
    void Death(object sender, EventArgs args)
    {
        _canMove = false;
    }

    void UpdateAmmoText()
    {
        _ammoText.text = String.Concat("Ammo: ", _inventory.Ammo[(int) _inventory.CurrentGun].ToString());
    }

    public void GainAmmo(Guns weapon, int amount)
    {
        _inventory.Ammo[(int)weapon] += amount;
    }
}
