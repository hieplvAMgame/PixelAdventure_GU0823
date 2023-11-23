using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class MoveChicken : IState
{
    public MoveChicken(Rigidbody2D rb, Enemy enemy) : base(rb, enemy)
    {
    }
    public override void OnEnter()
    {
        //enemy.animator.Play("Idle");
    }
    public override void OnExit()
    {
        rb.velocity = Vector2.zero;
    }
    public override void OnFrameUpdate()
    {
        //if (enemy.counter > enemy.timeDelayAttack)
            enemy.GetComponent<StateMachine>().ChangeState(ENEMY_STATE.ATTACK);
    }
    public override void OnPhysicsUpdate()
    {
        if (enemy.isFacingRight)
        {
            if (enemy.transform.localPosition.x <= enemy.limitX)
                rb.velocity = new Vector2(enemy.moveSpeed, rb.velocity.y);
            else
            {
                enemy.transform.localScale = new Vector3(-1, 1, 1);
                enemy.isFacingRight = false;
            }
        }
        else
        {
            if (enemy.transform.localPosition.x >= -enemy.limitX)
                rb.velocity = new Vector2(-enemy.moveSpeed, rb.velocity.y);
            else
            {
                enemy.transform.localScale = new Vector3(1, 1, 1);
                enemy.isFacingRight = true;
            }
        }
    }
}
