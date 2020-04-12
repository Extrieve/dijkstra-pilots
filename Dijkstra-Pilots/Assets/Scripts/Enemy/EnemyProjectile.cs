using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    public int damage = 50;
    public AudioSource shootSound;


    void Start()
    {
        shootSound = GameObject.Find("Shoot1").GetComponent<AudioSource>();
        shootSound.Play();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        
        else if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Was Shot");
            other.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
