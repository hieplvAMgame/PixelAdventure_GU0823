using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] Sprite[] idleSprites;
    [SerializeField] int speedAnim;
    int count;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = idleSprites[0];
    }
    public int countFrame;
    // Update is called once per frame
    void Update()
    {
        countFrame = Time.frameCount;
        if (Time.frameCount % speedAnim == 0)
        {
            Debug.LogError("Change Sprite");
            count++;
            if(count>=idleSprites.Length)
                count = 0;
            spriteRenderer.sprite = idleSprites[count];
        }
    }
}
