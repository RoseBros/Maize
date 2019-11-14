using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Controls controls;
    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private float playerSpeed = 50f;
    private Vector3 movementForce;
    public bool isMoving;
    public void Awake()
    {
        controls = new Controls();
        controls.FarmBoy.Move.performed += ctx => HandleMove(ctx.ReadValue<Vector2>());
        controls.FarmBoy.Move.canceled += ctx => isMoving = false;
        controls.FarmBoy.Run.performed += ctx => HandleRun();
        controls.FarmBoy.Flashlight.performed += ctx => HandleFlashlight();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    private void FixedUpdate()
    {
        Debug.Log(isMoving);
        Move();
    }
    private void Move()
    {
        playerBody.AddForce(movementForce * playerSpeed);
    }
    private void HandleRun()
    {
        Debug.Log("Run");
    }
    private void HandleMove(Vector2 direction)
    {
        isMoving = true;
        movementForce = new Vector3(direction.x, 0f, direction.y);
        Debug.Log("WASD moved" + direction);
    }
    private void HandleFlashlight()
    {
        Debug.Log("WASD moved");
    }

    // Use Update to read data
}
