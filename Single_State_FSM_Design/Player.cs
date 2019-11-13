using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _flashlight;
    public StateMachine StateMachine => GetComponent<StateMachine>(); //Not efficent; Do not call constantly
    private void Awake()
    {
        InitializeStateMachine();
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
}
