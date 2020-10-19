using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _mouseSensitivity = 10f;
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] Camera _cam;
    CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Movement();
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
}
