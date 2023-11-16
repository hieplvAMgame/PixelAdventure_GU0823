using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class IState
{
    protected Rigidbody2D rb { get; set; }
    protected Enemy enemy { get; set; }
    public IState(Rigidbody2D rb, Enemy enemy)
    {
        this.rb = rb;
        this.enemy = enemy;
    }
    public virtual void OnEnter() { }
    public virtual void OnExit() { }
    public virtual void OnFrameUpdate() { }
    public virtual void OnPhysicsUpdate() { }

}
