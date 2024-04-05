using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Enemies
{
    private void Start()
    {
        EnemyStart();
        health = 100;
        moveSpeed = 1.0f;
    }

    private void Update()
    {
        EnemyUpdate();
    }

    private void FixedUpdate()
    {
        EnemyFixedUpdate();
    }
}
