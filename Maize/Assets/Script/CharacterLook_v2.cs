using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterLook_v2 : MonoBehaviour
{
    //Unity Objects Need to link
    public GameObject flashlight;
    public CharacterController controller;
    public Transform playerBody;
    public Transform playerHead;

    //Setting variables
    public float movementSpeed = 12f;
    public float lookSensitivity = 20f; //20 is ok for mouse, too slow for controller

    //Variables
    private PlayerControls controls;
    private float xRotation = 0f, yRotation = 0f;
    private Vector2 move, look;
    private bool isGrounded;

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
        playerBody.Rotate(Vector3.up * look.x * lookSensitivity * Time.deltaTime);
        //yRotation += look.x * lookSensitivity * Time.deltaTime;
        xRotation -= look.y * lookSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
    void Flashlight()
    {
        flashlight.SetActive(!flashlight.activeSelf);
    }
    void Jump()
    {
        
    }
    void Interact()
    {

    }
    void Sprint()
    {

    }
}
