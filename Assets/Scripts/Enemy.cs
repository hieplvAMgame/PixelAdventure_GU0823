
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] CharacterData data;
    public CharacterAttributeHandle characterAttributeHandle;
    public Animator animator;

    [Header("Moving")]
    public float limitX;
    public float delayTimeAttack;
    public float moveSpeed;
    public bool isFacingRight = true;
    [Header("Die")]
    public float jumpDieForce;

    [Header("Attack")]
    public float timeDelayAttack;
    public float counter;
    private void Awake()
    {
        characterAttributeHandle = new CharacterAttributeHandle(data);
        characterAttributeHandle.Init();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
