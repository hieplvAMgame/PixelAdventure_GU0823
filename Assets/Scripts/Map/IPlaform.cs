using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlaform
{
    Animator anim { get; set; }
    PlaformScriptableData data { get; set; }
    void Setup(Animator anim, PlaformScriptableData data);
    void OnAction();
    void OnUpdate();
    void OnPhysicsUpdate();
    void OnExit();
    
}

// Item: + Idle, Enter
// Buff: + Idle, Enter
// Trap: + Idle -> Imortals
// None: + idle, Moving
public enum Plaform_State
{
    Idle,
    Action,
}
