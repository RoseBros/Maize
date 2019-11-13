using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleState : BaseState
{
    private Player _player;
    public idleState(Player player) : base(player.gameObject)
    {
        _player = player;
    }
    public override Type Tick()
    {
        //Logic for next state
        //_player.SomeAction(); //Do things to the player
        throw new NotImplementedException();
    }
}
