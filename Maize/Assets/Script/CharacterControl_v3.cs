using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControl_v3 : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private GameObject flashlight;
    [SerializeField] private LayerMask groundMask;  
    [SerializeField] private float lookSensitivity = 20f; //20 is ok for mouse, 300 for controller
    [SerializeField] private float movementSpeed = 8f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float runMultiplier = 3f;
    [SerializeField] private float groundDistance = 0.1f;
    private float gravity = -9.8f;

    private PlayerControls controls;
    private CharacterController controller;
    private Animator anim;
    private RaycastHit hit;
    private bool isMoving, isGrounded, isJumping, isRunning;
    private Vector2 moveInput;
    private Vector3 yRotation;
    private float xRotation = 0f;
    private Vector3 velocity;
    private float movementSpeedModifier = 1f;
    private int movementDirection, moveState;
    private void Awake()
    {
        controls = new PlayerControls();
        //Movement
        controls.Gameplay.Move.performed += ctx => HandleMove(true, ctx.ReadValue<Vector2>());
        controls.Gameplay.Move.canceled += ctx => HandleMove(false, ctx.ReadValue<Vector2>());
        //Look
        controls.Gameplay.Look.performed += ctx => HandleLook(ctx.ReadValue<Vector2>());
        controls.Gameplay.Look.canceled += ctx => yRotation = Vector3.zero;
        //Flashlight
        controls.Gameplay.Flashlight.performed += ctx => HandleFlashlight();
        //Jump
        controls.Gameplay.Jump.performed += ctx => HandleJump();
        //Interact
        controls.Gameplay.Interact.performed += ctx => HandleInteract();
        //Run
        controls.Gameplay.Run.performed += ctx => Debug.Log("pressed");  HandleRun(true);
        controls.Gameplay.Run.canceled += ctx => Debug.Log("released"); HandleRun(false);
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    private void Update()
    {
        Look();
        Move();
        Jump();
    }
    private void Jump()
    {
        //isGrounded = Physics.SphereCast(groundCheck.position, controller.radius, Vector3.down, out hit, groundDistance);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isJumping)
        {
            if (velocity.y < 0 && isGrounded)// if character is falling and hits ground they landed jump
            {
                isJumping = false;
                velocity.y = 0f;
                anim.SetInteger("jumpState", 0);
            }
            else //otherwise they are in air
            {
                velocity.y += gravity * Time.deltaTime;
                //anim.SetInteger("jumpState", 2);
            }
        }
        updateVelocity();
    }
    private void updateVelocity()
    {
        controller.Move(velocity * Time.deltaTime);
    }
    private void Move()
    {
        Vector3 m = (transform.right * moveInput.x + transform.forward * moveInput.y);
        controller.Move(m * movementSpeed * movementSpeedModifier * Time.deltaTime);
        if (isRunning)
            moveState = 2;
        if (isMoving && !isRunning)
            moveState = 1;
        if (!isMoving)
            moveState = 0;
        anim.SetInteger("moveState", moveState * movementDirection);
    }
    private void Look()
    {
        transform.Rotate(yRotation);
        groundCheck.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
    private void HandleJump()
    {
        if (isGrounded)
        {
            isJumping = true;
            anim.SetInteger("jumpState", 1); //start jump
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }    
    private void HandleRun(bool r)
    {
        Debug.Log("Run Pressed");
        isRunning = r;
        Debug.Log(isRunning);
        if (isRunning)
        {
            movementSpeedModifier = runMultiplier;
        }
        else
        {
            movementSpeedModifier = 1f;
        }
    }
    private void HandleMove(bool startMoving, Vector2 direction)
    {
        isMoving = startMoving;
        if (startMoving)
        {
            if (direction.y >= 0)
                movementDirection = 1;
            else
                movementDirection = -1;
            moveInput = direction;
        }
        else
        {
            moveState = 0; //stop moving
            moveInput = Vector2.zero;
        }
    }
    private void HandleLook(Vector2 direction)
    {
        yRotation = Vector3.up * direction.x * lookSensitivity * Time.deltaTime;
        xRotation -= direction.y * lookSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -25f, 25f); //Adjusted for third person
    }
    private void HandleFlashlight()
    {
        flashlight.SetActive(!flashlight.activeSelf);
    }
    private void HandleInteract()
    {
        Debug.Log("Interact");
    }
}
