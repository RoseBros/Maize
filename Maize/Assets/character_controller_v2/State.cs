using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected CharacterControl_v3 character;

    public abstract void Tick();

    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

    public State(CharacterControl_v3 character)
    {
        this.character = character;
    }
}