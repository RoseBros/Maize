﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControl_v2 : MonoBehaviour
{
    //Unity Objects Need to link
    public GameObject flashlight;
    public CharacterController controller;
    public Transform playerHead;

    //Setting variables
    public float jumpHeight = 3f;
    public float movementSpeed = 12f;
    public float lookSensitivity = 20f; //20 is ok for mouse, 300 for controller

    //Variables
    private float gravity = -9.8f;
    private PlayerControls controls;
    private float xRotation = 0f;
    private Vector2 move, look;
    private bool isGrounded;
    private Vector3 velocity;

        private void Awake()
    {
        controls = new PlayerControls();
        InputControlScheme scheme = controls.KeyboardMouseScheme;
        //Movement
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;
        //Look
        controls.Gameplay.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
        controls.Gameplay.Look.canceled += ctx => look = Vector2.zero;
        //Flashlight
        controls.Gameplay.Flashlight.performed += ctx => Flashlight();
        //Jump
        controls.Gameplay.Jump.performed += ctx => Jump();
        //Interact
        controls.Gameplay.Interact.performed += ctx => Interact();
        //Sprint
        controls.Gameplay.Sprint.performed += ctor => Sprint();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
    private void Update()
    {
        //Gravity

        //Move character controller
        Vector3 m = transform.right * move.x + transform.forward * move.y;
        controller.Move(m * movementSpeed * Time.deltaTime);
        //Look around
        Debug.Log(look);
        transform.Rotate(Vector3.up * look.x * lookSensitivity * Time.deltaTime);
        xRotation -= look.y * lookSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerHead.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
    void Flashlight()
    {
        flashlight.SetActive(!flashlight.activeSelf);
    }
    void Jump()
    {
        Debug.Log(Mathf.Sqrt(jumpHeight * -2f * gravity));
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
    void Interact()
    {

    }
    void Sprint()
    {

    }
}
