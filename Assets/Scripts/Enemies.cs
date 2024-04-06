using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [Header("4 different directions")]
    [SerializeField] private Sprite[] upAnimation;
    [SerializeField] private Sprite[] downAnimation;
    [SerializeField] private Sprite[] rightAnimation;
    [SerializeField] private Sprite[] leftAnimation;

    [Header("Starting directions")]
    [SerializeField] private Sprite[] sprites;

    [Header("Control physics")]
    [SerializeField] private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;
    private int spriteIndex = 0;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float health;

    private float curHealth;

    [SerializeField] private Transform healthBar;

    private int pathIndex = 0;
    private Transform pathTarget;

    protected void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        curHealth = health;
    }

    protected void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    protected void Update()
    {
        if (Vector2.Distance(pathTarget.position, transform.position) <= 0.05f)
        {
            pathIndex += 1;

            if (pathIndex == LevelManager.main.Path.Length)
            {
                Destroy(gameObject);
                return;
            }

            pathTarget = LevelManager.main.Path[pathIndex];

            Vector2 directionToNextPoint = (pathTarget.position - transform.position).normalized;

            if (Mathf.Abs(directionToNextPoint.x) > Mathf.Abs(directionToNextPoint.y))
            {
                if (directionToNextPoint.x > 0)
                {
                    // Move Right
                    sprites = rightAnimation;
                }
                else
                {
                    // Move Left
                    sprites = leftAnimation;
                }
            }
            else
            {
                if (directionToNextPoint.y > 0)
                {
                    // Move Up
                    sprites = upAnimation;
                }
                else
                {
                    sprites = downAnimation;
                    // Move Down
                }
            }
        }
    }

    protected void Start()
    {
        pathTarget = LevelManager.main.Path[pathIndex];
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    protected void FixedUpdate()
    {
        Vector2 direction = (pathTarget.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy (collision.gameObject);

            curHealth -= 20;

            if (curHealth <= 0)
            {
                Destroy(gameObject);
            }

            healthBar.transform.localScale = new Vector3(healthBar.localScale.x - (20 / health), 0.1f, 1f);
        }
    }
}
