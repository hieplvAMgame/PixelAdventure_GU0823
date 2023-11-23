using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
     bool isMove = false;
    float speed;
    Rigidbody2D rb;

    private void Awake()
    {
        rb=  GetComponent<Rigidbody2D>();
    }
    float dir;
    public void Setup(bool isMove, float speed, bool moveRight)
    {
        this.isMove = isMove;
        this.speed = speed;
        dir = moveRight ? 1 : -1;
    }
    private void FixedUpdate()
    {
        if (isMove)
            rb.velocity = new Vector2(dir * speed, 0);
    }
}
