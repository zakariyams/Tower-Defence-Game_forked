using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : Enemies
{
    private void Start()
    {
        EnemyStart();
        health = 10;
        moveSpeed = 5.0f;
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
