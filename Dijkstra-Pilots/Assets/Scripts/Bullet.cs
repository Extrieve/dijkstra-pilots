using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int projectileDamage;

    public GameObject hitEffect; 
    private void OnCollisionEnter2D(Collision2D collision)
    {
             
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Was Shot");
            other.gameObject.GetComponent<EnemyHealthManager>().DamageEnemy(projectileDamage);
            Destroy(gameObject);
        }
    }
}
