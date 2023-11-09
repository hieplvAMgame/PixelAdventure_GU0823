using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [Header("MOVEMENT")]
    [SerializeField] float moveSpeed;
    [HideInInspector] public float h_Input;
    bool isFacingRight = true;

    [Header("JUMP")]
    [SerializeField] float jumpForce;
    [SerializeField] float timeJump;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask layerGround;
    [SerializeField] float fallingMultile;

    //[SerializeField] int extraJumpTimes = 1;
    //int remainingJumpTimes;
    float timeCounter;
    [Header("WALL JUMP")]
    [SerializeField] Transform wallCheck;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] Vector2 wallJumpForce;
    [SerializeField] float wallJumpSpeed;
    public bool isTouchingWall;
    public bool isSliding;


    Vector2 velocityGravity;
    public bool isJumping;
    public bool isGrounded;
    private void Awake()
    {
        velocityGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }
    public void GetInput()
    {
        h_Input = Input.GetAxis("Horizontal");
        if ((h_Input < 0 && isFacingRight) || (h_Input > 0 && !isFacingRight))
            Flip();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            #region Double Jump
            //else if (remainingJumpTimes > 0)
            //{
            //    if (!isSliding)
            //    {
            //        rb.velocity = new Vector2(rb.velocity.x, jumpForce * .8f);
            //        remainingJumpTimes--;
            //    }
            //    //else
            //    //{
            //    //    rb.velocity = new Vector2(-h_Input * wallJumpForce.x, wallJumpForce.y);
            //    //}
            //}
            #endregion
        }
        if (Input.GetKeyUp(KeyCode.Space) && !isGrounded)
            isJumping = false;
    }
    public void CheckWorld()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(.8f, .2f), 0, layerGround);
        isTouchingWall = Physics2D.OverlapBox(wallCheck.position, new Vector2(.2f, .8f), 0, wallLayer);
    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        CheckWorld();
    }
    public void HandleOnAir()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity -= velocityGravity * fallingMultile * Time.deltaTime;
        }
        else if (rb.velocity.y > 0)
        {
            if (!isJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .7f);
                return;
            }
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
    }
    public void Jump()
    {
        if (isJumping && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            timeCounter = 0;
        }
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
        MoveHorizontal();
        WallSlide();
        WallJump();
        HandleOnAir();
        Jump();
    }
    public void MoveHorizontal()=> rb.velocity = new Vector2(h_Input * moveSpeed, rb.velocity.y);
    void WallSlide()
    {
        if (isTouchingWall && !isGrounded && rb.velocity.y < 0)
        {
            isSliding = true;
        }
        else
            isSliding = false;
        if (isSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallJumpSpeed, float.MaxValue));
        }
    }
    void WallJump()
    {
        if (isJumping && isSliding)
        {
            rb.velocity = new Vector2(wallJumpForce.x * (isFacingRight ? -1 : 1), wallJumpForce.y);
            Flip();
            isJumping = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(groundCheck.position, new Vector2(.8f, .2f));
        Gizmos.color = Color.green;
        Gizmos.DrawCube(wallCheck.position, new Vector2(.2f, .8f));
    }
}
