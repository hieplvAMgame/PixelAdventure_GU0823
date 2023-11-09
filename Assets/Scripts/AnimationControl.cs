using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl
{
    public Animator animator;

    public AnimationControl(Animator animator)
    {
        this.animator = animator;
    }
    public void PlayAnim(ANIM_ACTION anim)
    {
        for (int i = 0; i < Enum.GetValues(typeof(ANIM_ACTION)).Length; i++)
        {
            animator.SetBool(((ANIM_ACTION)i).ToString(), false);
        }
        animator.SetBool(anim.ToString(), true);
    }
}
public enum ANIM_ACTION
{
    Idle, Run, WallJump, Falling, DoubleJump, Hurt, Die, Jump, Hit
}
