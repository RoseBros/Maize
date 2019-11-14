using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveState : BaseState
{
    private Player _player;
    private Type nextState;
    public moveState(Player player) : base(player.gameObject)
    {
        _player = player;
    }
    public override Type Tick()
    {
        //Logic for next state
        //_player.SomeAction(); //Do things to the player
        //set animation to idle
        _player._controls.FarmBoy.Move.performed += ctx => nextState = typeof(moveState);
        _player.HandleIdle();
        return typeof(idleState);
    }
}
