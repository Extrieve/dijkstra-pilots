using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : BaseAI
{
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        //over time, move the enemy to a new location

        //if the player is in sight, attack them
    }
}
