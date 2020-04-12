using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public Slider healthBar;
    public Health health;
    private int startingHealth;
    private int currentHealth;

    void Start()
    {
        startingHealth = health.GetHealth();
        currentHealth = startingHealth;
        healthBar.value = currentHealth;
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            //Game Over Needs to Be Innitiated in Here or Call to Another Script to Start Game Over
        }
    }

    public void TakeDamage(int damage)
    {
        health.ChangeHealth(-damage);
        healthBar.value -= damage;
        if(healthBar.value <= 0)
        {
            healthBar.value = 0;
        }
    }

}
