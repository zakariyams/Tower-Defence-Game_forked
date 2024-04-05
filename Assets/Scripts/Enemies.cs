using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private int enemiesPerWave;
    private float moveSpeed;
    private int hp1;

    [SerializeField] private Rigidbody2D[] enemyType;

    private int stage1;
    private int stage2;

    private int pathIndex = 0;
    private Transform pathTarget;
    [SerializeField]private Rigidbody2D rb;

    //private spawncounter;


    private void  Endwave()
    {
        
    }

    // Update is called once per frame
    /*private void SpawnEnemy()
    {
     
        
        stage1 = 200;

        if (stage == 1)
        { 
            for (int i = 0; i < stage1; i++)
            {
                speedyflamingo++;
            }
        }
    }*/





    private int EnemiesPerWave()
    {
        // enemies per wave 1, 2,3,4 and 5 so far 
        return 0;
    }

    private void Update()
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

    private void Start()
    {
        pathTarget = LevelManager.main.Path[pathIndex];
        moveSpeed = 4.0f;
    }

    private void FixedUpdate()
    {
        Vector2 direction = (pathTarget.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }
}
