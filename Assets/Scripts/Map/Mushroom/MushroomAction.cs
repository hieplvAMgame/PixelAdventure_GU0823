using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAction : MonoBehaviour, IPlaform
{
    public Animator anim { get; set; }
    public PlaformScriptableData data { get ; set ; }

    public void OnAction()
    {
        anim.Play(Plaform_Anim_State.Action);
    }

    public void OnExit()
    {
    }

    public void OnPhysicsUpdate()
    {
    }

    public void OnUpdate()
    {
    }

    public void Setup(Animator anim, PlaformScriptableData data)
    {
        this.anim = anim;
        this.data = data;
    }

}
