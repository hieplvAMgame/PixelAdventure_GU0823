
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
    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        characterAttributeHandle = new CharacterAttributeHandle(data);
        animationHandle = GetComponent<AnimationHandle>();
        characterAttributeHandle.Init();
        stateMachine.SetUp();
        this.WaitForSeconds(2, () => stateMachine.ChangeState(ENEMY_STATE.DIE));
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
}
