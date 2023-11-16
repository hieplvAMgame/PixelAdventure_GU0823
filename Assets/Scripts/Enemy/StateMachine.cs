using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateMachine : MonoBehaviour
{
    public MoveChicken moveState;
    public DieChicken dieState;
    public AttackChicken attackState;
    public IState currentState;
    Rigidbody2D rb;
    Enemy enemy;
    Dictionary<ENEMY_STATE, IState> state_dict = new Dictionary<ENEMY_STATE, IState>();
    public Button btnChangeState;
    private void Awake()
    {

        btnChangeState.onClick.AddListener(() => ChangeState(dieState));
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();

        moveState = new MoveChicken(rb, enemy);
        dieState = new DieChicken(rb, enemy);
        attackState = new AttackChicken(rb, enemy);
        state_dict.Add(ENEMY_STATE.MOVE, moveState);
        state_dict.Add(ENEMY_STATE.DIE, dieState);
        state_dict.Add(ENEMY_STATE.ATTACK, attackState);

        currentState = moveState;
    }
    private void Update()
    {
        enemy.counter += Time.deltaTime;
        currentState.OnFrameUpdate();
    }
    private void FixedUpdate()
    {
        currentState.OnPhysicsUpdate();
    }

    IState GetStateByEnum(ENEMY_STATE state) => state_dict[state];
    public void ChangeState(ENEMY_STATE state)
    {
        currentState.OnExit();
        currentState = GetStateByEnum(state);
        currentState.OnEnter();
    }
    public void ChangeState(IState nextState)
    {
        currentState.OnExit();
        currentState = nextState;
        currentState.OnEnter();
    }
    public void ChangeStateDelay(float time, ENEMY_STATE state)
    {
        this.WaitForSeconds(time, () => ChangeState(state));
    }
}
public enum ENEMY_STATE
{
    MOVE,
    DIE,
    ATTACK
}
