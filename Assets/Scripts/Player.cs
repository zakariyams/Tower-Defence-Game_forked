using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex = 0;


    void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f , 0.15f);
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length) 
        { 
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    // Update is called once per frame
    private void Update()
    {

    }
}
