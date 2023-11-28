using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlime : MonoBehaviour, IEnemyState
{
    Enemy enemy;
    public ENEMY_STATE state { get; set; }
    public Rigidbody2D rb { get; set; }

    public void OnEnter()
    {
        enemy.animationHandle.PlayAnim(state);
    }

    public void OnExit()
    {
    }

    public void OnPhysicUpdate()
    {
        Vector2 pos = rb.position;
        pos.x += (enemy.isFacingRight ? 1 : -1) * enemy.moveSpeed * Time.fixedDeltaTime;
        if (pos.x >= enemy.maxX)
        {
            pos = new Vector2(enemy.maxX, pos.y);
            enemy.Flip();
        }
        else if (pos.x <= enemy.minX)
        {
            pos = new Vector2(enemy.minX, pos.y);
            enemy.Flip();

        }
        rb.MovePosition(pos);
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
