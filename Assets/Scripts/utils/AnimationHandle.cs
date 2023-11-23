using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Diagnostics.Contracts;

public class AnimationHandle : MonoBehaviour
{
    Animator animator;
    Dictionary<ENEMY_STATE, string> animDict = new Dictionary<ENEMY_STATE, string>()
    {
        {ENEMY_STATE.IDLE,Name_Anim.Idle },
        {ENEMY_STATE.ATTACK,Name_Anim.Attack },
        {ENEMY_STATE.MOVE,Name_Anim.Move },
        {ENEMY_STATE.DIE,Name_Anim.Die }
    };
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayAnim(ENEMY_STATE state)
    {
        animator.Play(animDict[state]);
    }
}
public struct Name_Anim
{
    public const string Idle = "Idle";
    public const string Attack = "Attack";
    public const string Die = "Die";
    public const string Move = "Move";
}
