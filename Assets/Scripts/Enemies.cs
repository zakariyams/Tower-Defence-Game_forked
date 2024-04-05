using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    protected float moveSpeed;
    protected int health;

    [SerializeField] private Rigidbody2D[] enemyType;

    private int pathIndex = 0;
    private Transform pathTarget;
    [SerializeField]private Rigidbody2D rb;

    private void Start()
    {
        EnemyStart();
    }

    private void Update()
    {
        EnemyUpdate();
    }

    private void FixedUpdate()
    {
        EnemyFixedUpdate();
    }

    protected void EnemyUpdate()
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
        }
    }

    protected void EnemyStart()
    {
        pathTarget = LevelManager.main.Path[pathIndex];
        moveSpeed = 4.0f;
    }

    protected void EnemyFixedUpdate()
    {
        Vector2 direction = (pathTarget.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }
}
