using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemy : Enemies
{
    private void Start()
    {
        EnemyStart();
        health = 50;
        moveSpeed = 2.5f;
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
