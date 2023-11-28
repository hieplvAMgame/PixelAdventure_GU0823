using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSlime :MonoBehaviour, IEnemyState
{
    Enemy enemy;
    public ENEMY_STATE state { get ; set ; }
    public Rigidbody2D rb { get; set ; }

    public void OnEnter()
    {
        enemy.animationHandle.PlayAnim(state);
        enemy.OnDie();
        rb.velocity = Vector3.up * enemy.jumpDieForce;
        // Spawn 1 die particle
    }

    public void OnExit()
    {
    }

    public void OnPhysicUpdate()
    {
    }

    public void OnUpdate()
    {
    }

    public void SetEnemy(Enemy enemy, Rigidbody2D rb, ENEMY_STATE state)
    {
        this.enemy = enemy;
        this.rb = rb;
        this.state = state;
    }
}
