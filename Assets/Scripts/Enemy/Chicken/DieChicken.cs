using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class DieChicken : IState
{
    public DieChicken(Rigidbody2D rb, Enemy enemy) : base(rb, enemy)
    {
    }

    public override void OnEnter()
    {
        Debug.LogError("Enemy Die");
        enemy.GetComponent<SpriteRenderer>().sortingOrder = 10;
        enemy.GetComponent<Collider2D>().isTrigger = true;
        rb.velocity = new Vector2(rb.velocity.x, enemy.jumpDieForce);
        enemy.animator.Play("Hit");
    }

    public override void OnExit()
    {

    }

    public override void OnFrameUpdate()
    {
    }

    public override void OnPhysicsUpdate()
    {
        if (rb.velocity.y < 0)
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 1.3f);
    }
}
