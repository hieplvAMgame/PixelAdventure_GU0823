using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class StateMachineHandle : SerializedMonoBehaviour
{
    Rigidbody2D rb;
    Enemy enemy;
    [SerializeField]
    Dictionary<ENEMY_STATE, IEnemyState> stateDict = new Dictionary<ENEMY_STATE, IEnemyState>();
    public IEnemyState currentState;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
    }
    public void ChangeState(ENEMY_STATE state)
    {
        currentState.OnExit();
        currentState = stateDict[state];
        currentState.OnEnter();
    }

    public void SetUp()
    {
        foreach (var state in stateDict.Keys)
        {
            stateDict[state].SetEnemy(enemy, rb, state);
        }
        currentState = stateDict[ENEMY_STATE.IDLE];
        currentState.OnEnter();
    }
    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
    }
    private void FixedUpdate()
    {
        currentState.OnPhysicUpdate();
    }
    public void ChangeStateDelay(float delay, ENEMY_STATE state)
    {
        this.WaitForSeconds(delay, () => ChangeState(state));
    }
}
public enum ENEMY_STATE
{   
    IDLE,
    MOVE,
    DIE,
    ATTACK
}
public interface IEnemyState
{
    ENEMY_STATE state { get; set; }
    Rigidbody2D rb { get; set; }
    void SetEnemy(Enemy enemy, Rigidbody2D rb, ENEMY_STATE state);

    void OnEnter();
    void OnExit();
    void OnUpdate();
    void OnPhysicUpdate();
}