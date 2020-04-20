using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollision : MonoBehaviour
{
    public AudioSource spikeHit;
    


    void Start()
    {
        spikeHit = GameObject.Find("Crash1").GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            spikeHit.Play();
            // PlayerHealthManager.health.ChangeHealth(5);
            Destroy(other);
        }
       
    }
}
