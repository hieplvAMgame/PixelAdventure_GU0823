using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] CharacterData data;
    public CharacterAttributeHandle characterAttributeHandle;
    PlayerController playerController;
    public HpBarUI hpBar;
    private void Awake()
    {
        characterAttributeHandle = new CharacterAttributeHandle(data);
        characterAttributeHandle.Init();
        playerController = GetComponent<PlayerController>();
        hpBar.OnInit(data.hp);
    }
    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Game_Tag.Enemy))
        {
            Debug.LogError("Collision with enemy");
            collision.gameObject.TryGetComponent(out Enemy enemy);
            characterAttributeHandle.TakenDame(enemy.characterAttributeHandle.GetAtk(), (isDie) =>
            {
                hpBar.OnChangeHP(-enemy.characterAttributeHandle.GetAtk());
                if (isDie)
                {
                    // anim Die
                    // Show Game Over
                    // Pause game
                    // Show score
                    // ....
                }
                else
                {
                    Debug.LogError("Hit");
                    // Show vfx
                    // Bat Sfx
                    // ...
                }
            });
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Game_Tag.Point))
        {
            Debug.LogError("Kill enemy");
            playerController.JumpOnKill();
            collision.transform.parent.gameObject.SetActive(false);
        }
    }
}
