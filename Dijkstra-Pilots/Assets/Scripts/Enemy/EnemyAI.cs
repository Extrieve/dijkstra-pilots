﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed;
    //This is how far the enemy stops from the player
    public float stoppingDistance;
    //When the enemy should back away from the player
    public float retreatDistance;
    //When the enemy should start attacking the enemy
    public float bulletForce = 20f;
    public float attackDistance;
    private float timeBtwShots;
    public float startTimeBtwShots;

    private Rigidbody2D rb;
    private float waitTime;
    //How long they should wait before moving to a new waypoint
    public float startWaitTime;

    //The projectile is what the enemy will be shooting
    public GameObject projectile;
    public Health health;
    public Transform player;

    //The array to contain the waypoints that the enemy needs to move to
    private List<Transform> moveSpots = new List<Transform>();
    private int randomSpot;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;

        waitTime = startWaitTime;
        GetMoveSpots();
        randomSpot = Random.Range(0, moveSpots.Count);
    }

    void Update()
    {
        //If the player is in range of attackDistance then begin attacking, otherwise patrol
        if (Vector2.Distance(transform.position, player.position) <= attackDistance)
        {
            transform.up = player.position - transform.position;

            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                Vector3 target = player.transform.position;
            }

            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }

            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -moveSpeed * Time.deltaTime);
            }

            if (timeBtwShots <= 0)
            {
                timeBtwShots = startTimeBtwShots;
                GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
            }

            else
            {
                timeBtwShots -= Time.deltaTime;
            }

        }

        else
        {
            for (int i = moveSpots.Count - 1; i > -1; i--)
                if (moveSpots[i] == null)
                    moveSpots.RemoveAt(i);

            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Count);
                    waitTime = startWaitTime;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void OnCollision2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("PlayerProjectile"))
        {
            health.ChangeHealth(-50);
            if(health.GetHealth() == 0)
            {
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
        }
    }

    public void GetMoveSpots()
    {
        foreach (GameObject point in GameObject.FindGameObjectsWithTag("MovePoint"))
            moveSpots.Add(point.transform);
    }
}
