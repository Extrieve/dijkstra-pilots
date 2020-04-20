using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public Health health;
    private int currentHealth;
    public AudioSource destroySound;

    void Start()
    {
        currentHealth = health.GetHealth();
        destroySound = GameObject.Find("Crash2").GetComponent<AudioSource>();
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            destroySound.Play();
            if (Timer.t < 5)
            {
                ScoreScript.scoreValue += 30;
            }else if (Timer.t < 15)
            {
                ScoreScript.scoreValue += 20;
            }else
            {
                ScoreScript.scoreValue += 10;
            }
        }
    }

    public void DamageEnemy(int damage)
    {
        Debug.Log("Enemy Took damage");
        currentHealth += -damage;
        health.ChangeHealth(-damage);
    }
}
