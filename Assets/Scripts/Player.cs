using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] CharacterData data;
    public CharacterAttributeHandle characterAttributeHandle;
    public AnimationControl anim;
    PlayerController playerController;
    public HpBarUI hpBar;
    private void Awake()
    {
        characterAttributeHandle = new CharacterAttributeHandle(data);
        anim = new AnimationControl(GetComponent<Animator>());
        characterAttributeHandle.Init();
        playerController = GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (playerController.isGrounded)
        {
            if (Mathf.Abs(playerController.h_Input) > .1f)  
                anim.PlayAnim(ANIM_ACTION.Run);
            else
                anim.PlayAnim(ANIM_ACTION.Idle);
        }
        else
        {
            if(playerController.rb.velocity.y>0)
                anim.PlayAnim(ANIM_ACTION.Jump);
            else
                anim.PlayAnim(ANIM_ACTION.Falling);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Game_Tag.Enemy))
        {
            collision.gameObject.TryGetComponent(out Enemy enemy);
            characterAttributeHandle.TakenDame(enemy.characterAttributeHandle.GetAtk(), (isDie) =>
            {
                if (isDie)
                {
                    anim.PlayAnim(ANIM_ACTION.Die);
                    // Show Game Over
                    // Pause game
                    // Show score
                    // ....
                }
                else
                {
                    Debug.LogError("Hit");
                    anim.PlayAnim(ANIM_ACTION.Hit);
                    // Show vfx
                    // Bat Sfx
                    // ...
                }
            });
        }
    }
}
