using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("MOVEMENT")]
    [SerializeField] float moveSpeed;
    [SerializeField] float h_Input;
    bool isFacingRight = true;

    [Header("JUMP")]
    [SerializeField] float jumpForce;
    [SerializeField] float timeJump;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask layerGround;
    [SerializeField] float fallingMultile;

    [SerializeField] int extraJumpTimes = 1;
    int remainingJumpTimes;
    float timeCounter;
    [Header("WALL JUMP")]
    [SerializeField] Transform wallCheck;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] Vector2 wallJumpForce;
    [SerializeField] float wallJumpSpeed;
    bool isWalled;
    bool isSliding;


    Vector2 velocityGravity;
    bool isJumping;
    bool isGrounded;
    private void Awake()
    {
        velocityGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h_Input = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(.8f, .2f), 0, layerGround);
        isWalled = Physics2D.OverlapBox(wallCheck.position, new Vector2(.2f, .8f), 0, wallLayer);
        if ((h_Input < 0 && isFacingRight) || (h_Input > 0 && !isFacingRight))
            Flip();
        #region JUMP
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                remainingJumpTimes = extraJumpTimes;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isJumping = true;
                timeCounter = 0;
            }
            else if (remainingJumpTimes > 0)
            {
                if (!isSliding)
                {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * .8f);
                remainingJumpTimes--;
                }
                else
                {
                    rb.velocity = new Vector2(-h_Input * wallJumpForce.x, wallJumpForce.y);
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) && !isGrounded)
        {
            isJumping = false;
            if (rb.velocity.y > 0)
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .7f);
        }
        // Apply more gravity - player falling fast
        if (rb.velocity.y < 0)
        {
            rb.velocity -= velocityGravity * fallingMultile * Time.deltaTime;
        }
        else
        if (rb.velocity.y > 0 && isJumping)
        {
            timeCounter += Time.deltaTime;
            if (timeCounter > timeJump) isJumping = false;
            float curMultiple = fallingMultile;
            float t = timeCounter / timeJump;
            if (t > .5f)
            {
                curMultiple = fallingMultile * (1 - t);
                rb.velocity += velocityGravity * curMultiple * Time.deltaTime;
            }
        }
        #endregion

        #region WALL JUMP
        if (isWalled && !isGrounded && h_Input != 0)
        {
            isSliding = true;
            remainingJumpTimes = extraJumpTimes;
        }
        else
            isSliding = false;

        #endregion
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        float x = transform.localScale.x;
        x = -x;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(h_Input * moveSpeed, rb.velocity.y);
        if (isSliding)
        {
            rb.velocity = new Vector2(0, Mathf.Clamp(rb.velocity.y, -wallJumpSpeed, float.MaxValue));
        }
    }
}
