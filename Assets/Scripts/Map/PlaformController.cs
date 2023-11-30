using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaformController : SerializedMonoBehaviour
{
    Animator animator;
    public PlaformScriptableData data;
    public Dictionary<Plaform_State, IPlaform> states = new Dictionary<Plaform_State, IPlaform>();
    IPlaform currentState;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        foreach(Plaform_State key in states.Keys)
        {
            states[key].Setup(animator,data);
        }
        currentState = states[Plaform_State.Idle];
        currentState.OnAction();
    }
    public void ChangeState(Plaform_State state)
    {
        currentState.OnExit();
        currentState = states[state];
        currentState.OnAction();
    }
    public void ChangeState(int state)
    {
        ChangeState((Plaform_State)state);
    }
    private void Update()
    {
        currentState.OnUpdate();
    }
    private void FixedUpdate()
    {
        currentState.OnPhysicsUpdate();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.TryGetComponent(out PlayerController player);
            ChangeState(Plaform_State.Action);
            player.HigherJump(data.multiple, data.duration);
        }
    }
}
public struct Plaform_Anim_State
{
    public const string Idle = "Idle";
    public const string Action = "Action";
}