using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControl_v2 : MonoBehaviour
{
    //Unity Objects Need to link
    public GameObject flashlight;
    //public CharacterController controller;
    public Transform playerHead;

    //Setting variables
    public float jumpHeight = 3f;
    public float movementSpeed = 8f;
    public float sprintMultiplier = 3f;
    public float lookSensitivity = 20f; //20 is ok for mouse, 300 for controller

    //Variables
    private Animator anim;
    private CharacterController controller;
    
    private PlayerControls controls;
    private float movementMultiplier = 1f;
    private float gravity = -9.8f;
    private float xRotation = 0f;
    private Vector2 move, look;
    private bool isGrounded;
    private Vector3 velocity;

        private void Awake()
    {
        controls = new PlayerControls();
        //InputControlScheme scheme = controls.KeyboardMouseScheme;
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
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
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
        velocity.y += gravity * Time.deltaTime;
        //Move character controller
        Walk();
        Vector3 m = transform.right * move.x + transform.forward * move.y;
        controller.Move(m * movementSpeed * movementMultiplier * Time.deltaTime);
        //Character is grouned
        if (controller.isGrounded)
        {
            anim.SetInteger("jumpState", 0);
        }
        //Look around
        transform.Rotate(Vector3.up * look.x * lookSensitivity * Time.deltaTime);
        xRotation -= look.y * lookSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -45f, 25f);
        playerHead.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //Sprint
        if (UnityEngine.Input.GetButtonDown("Sprint"))
            movementMultiplier = sprintMultiplier;
        if (UnityEngine.Input.GetButtonUp("Sprint"))
            movementMultiplier = 1f;
        //Update Velocity
        controller.Move(velocity * Time.deltaTime);
    }
    void Flashlight()
    {
        flashlight.SetActive(!flashlight.activeSelf);
    }
    void Walk()
    {
        switch (move.y)
        {
            case -1:
                anim.SetInteger("isWalking", -1); break;
            case 0:
                anim.SetInteger("isWalking", 0); break;
            case 1:
                anim.SetInteger("isWalking", 1); break;
        }
    }
    void Jump()
    {
        if (controller.isGrounded)
        {
            anim.SetInteger("jumpState", 1);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
    void Interact()
    {

    }
}
