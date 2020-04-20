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
    public AudioSource deathSound;

    void Start()
    {
        startingHealth = health.GetHealth();
        currentHealth = startingHealth;
        healthBar.value = currentHealth;
        deathSound = GameObject.Find("Explosion3").GetComponent<AudioSource>();
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            //Game Over Needs to Be Innitiated in Here or Call to Another Script to Start Game Over
            deathSound.Play();
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
