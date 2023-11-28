
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    SpriteRenderer spr;
    Collider2D col;
    [SerializeField] CharacterData data;
    public CharacterAttributeHandle characterAttributeHandle;
    public AnimationHandle animationHandle;
    public StateMachineHandle stateMachine;
    [Header("Moving")]
    public float limitX;
    public float maxX, minX;
    public float delayTimeAttack;
    public float moveSpeed;
    public bool isFacingRight = true;
    [Header("Die")]
    public float jumpDieForce;

    [Header("Attack")]
    public GameObject bullet;
    public float bulletSpeed;
    public Transform shootingPoint;
    public float delayTime = 1;
    float count = 0;

    public void Shoot()
    {
        GameObject clone = Instantiate(bullet, shootingPoint.position, Quaternion.identity);
        clone.TryGetComponent(out Bullet bl);
        bl.Setup(true, bulletSpeed,isFacingRight);
    }
    Vector2 directionToRay()
    {
        float x = transform.position.x + (isFacingRight ? 1 : -1) * distanceCheck;
        return new Vector2(x,transform.position.y);
    }
    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z); ;
    }
    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        characterAttributeHandle = new CharacterAttributeHandle(data);
        animationHandle = GetComponent<AnimationHandle>();
        characterAttributeHandle.Init();
        stateMachine.SetUp();
        //this.WaitForSeconds(2, () => stateMachine.ChangeState(ENEMY_STATE.DIE));
    }
    public bool canShoot = false;
    public float distanceCheck;
    private void Update()
    {
    }
    public void OnDie()
    {
        spr.sortingOrder = 5;
        col.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    //Debug

    public void ChangeState(int state)
    {
        stateMachine.ChangeState((ENEMY_STATE)state);
    }
}
