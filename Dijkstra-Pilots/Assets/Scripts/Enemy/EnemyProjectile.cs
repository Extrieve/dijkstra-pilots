using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;

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
        if (other.CompareTag("Player")  || other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

}
