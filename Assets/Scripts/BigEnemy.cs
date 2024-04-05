using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Enemies
{
    private void Start()
    {
        EnemyStart();
        health = 500;
        moveSpeed = 0.5f;
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
