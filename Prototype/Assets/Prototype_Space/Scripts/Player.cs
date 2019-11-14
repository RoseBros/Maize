using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _flashlight;
    public Controls _controls;
    public StateMachine StateMachine => GetComponent<StateMachine>(); //Not efficent; Do not call constantly
    private void Awake()
    {
        _controls = new Controls();
        InitializeStateMachine();
    }
    private void OnEnable()
    {
        _controls.Enable();
    }
    private void OnDisable()
    {
        _controls.Disable();
    }
    private void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>() //First Entry is initial state
        {
            { typeof(idleState), new idleState(player:this) }
        };
        GetComponent<StateMachine>().SetStates(states);
    }
    //TODO Add player actions here
    public void HandleIdle()
    {
        Debug.Log("Idle");
    }
    private void HandleRun()
    {
        Debug.Log("Run");
    }
    private void HandleMove(Vector2 direction)
    {
        Debug.Log("WASD moved" + direction);
    }
    private void HandleFlashlight()
    {
        Debug.Log("WASD moved");
    }
}
