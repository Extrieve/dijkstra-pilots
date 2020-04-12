using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public Health health;
    private int currentHealth;

    void Start()
    {
        currentHealth = health.GetHealth();
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DamageEnemy(int damage)
    {
        Debug.Log("Enemy Took damage");
        currentHealth += -damage;
        health.ChangeHealth(-damage);
    }
}
