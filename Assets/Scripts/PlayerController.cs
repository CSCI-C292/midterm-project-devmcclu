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
    //Gun object meshes
    [SerializeField] GameObject[] _gunObjects = new GameObject[5];
    //Gun object shown
    GameObject _currentGun;
    CharacterController _characterController;
    GunController _gunController;

    // Start is called before the first frame update
    void Start()
    {
        //Make sure time is running correctly
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        GameEvents.LevelFinished += OnLevelEnd;
        GameEvents.PlayerDied += Death;
    }

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _gunController = GetComponentInChildren<GunController>();
        //Current gun that is shown on player
        _currentGun = _gunObjects[(int) _inventory.CurrentGun];
        //Make sure correct ammo is shown
        UpdateAmmoText();
    }

    // Update is called once per frame
    void Update()
    {
        if(_canMove)
        {
            Aim();
            Movement();

            //Only shoot if player can shoot
            if(Input.GetButton("Fire1") && _inventory.Ammo[(int) _inventory.CurrentGun] > 0)
            {
                //If the player did shoot, get rid of ammo
                if (_gunController.Shoot())
                {
                    _inventory.Ammo[(int) _inventory.CurrentGun] -= 1;
                    UpdateAmmoText();
                }
            }

            // if(Input.GetKeyDown(KeyCode.Alpha1))
            // {
            //     ChangeWeapon(Guns.Knife);
            // }
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeWeapon(Guns.Pistol);
            }
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeWeapon(Guns.Shotgun);
            }
            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                ChangeWeapon(Guns.Rifle);
            }
            if(Input.GetKeyDown(KeyCode.Alpha4))
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
            //Switch to the correct gun in the inventory
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
            
            //Change the bullet and fire rate
            _gunController.ChangeBullet(_inventory.AmmoPrefab[(int) weapon]);
            _gunController.ChangeTimer(_inventory.FireTimer[(int) weapon]);
            _gunController.ChangeAudioClip(_inventory.AudioClips[(int) weapon]);
            
            //Switch to the correct weapon mesh
            _currentGun.SetActive(false);
            _currentGun = _gunObjects[(int) weapon];
            _currentGun.SetActive(true);

            UpdateAmmoText();

            FindObjectOfType<AudioManager>().Play("ChangeWeapon");
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

    void OnDisable() 
    {
        GameEvents.LevelFinished -= OnLevelEnd;
        GameEvents.PlayerDied -= Death;
    }

    public void GainAmmo(Guns weapon, int amount)
    {
        _inventory.Ammo[(int)weapon] += amount;
    }
}
