using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private string status;
    public int health = 100; // health that determines when system is destroyed
    private int maxHealth;

    private void Awake()
    {
        maxHealth = health;
    }

    private void Update()
    {
        if(health <= 0)
        {
            health = 0;
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int hp)
    {
        health = hp;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void ChangeHealth(int changeAmt)
    {
        health += changeAmt;
    }
}
