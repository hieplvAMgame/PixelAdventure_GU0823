using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanDie : MonoBehaviour, IEnemyState
{
    Enemy enemy;
    public Rigidbody2D rb { get ; set; }
    public ENEMY_STATE state { get; set; }

    public void OnEnter()
    {
        enemy.animationHandle.PlayAnim(ENEMY_STATE.DIE);
        enemy.OnDie();
        rb.velocity = new Vector2(0, enemy.jumpDieForce);
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
