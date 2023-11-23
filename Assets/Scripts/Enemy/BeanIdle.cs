using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class BeanIdle : MonoBehaviour, IEnemyState
{
    Enemy enemy;
    public Rigidbody2D rb { get ; set; }
    public ENEMY_STATE state { get; set; }

    public void OnEnter()
    {
        enemy.animationHandle.PlayAnim(state);
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
