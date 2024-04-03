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
    private string name;
    [SerializeField] private Rigidbody2D[] enemyType;

    private int stage1;
    private int stage2;

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
       
    }

    private void Start()
    {
        
    }

}
