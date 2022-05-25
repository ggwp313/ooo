using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _playerBody;
    private Vector3 _movementInput;
    private Vector2 _mouseInput;

    [SerializeField]
    private Transform _playerCamera;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _sensetivity;
    [SerializeField]
    private float _jumpForce;

    private void Start()
    {
        _playerBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f , Input.GetAxis("Vertical"));
        _mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MovePlayerCamera();
    }

    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(_movementInput) * _speed;
        _playerBody.velocity = new Vector3(moveVector.x, _playerBody.velocity.y, moveVector.z);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _playerBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void MovePlayerCamera()
    {

    }
}
