using System.Collections;
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
    public float attackDistance;
    private float timeBtwShots;
    public float startTimeBtwShots;

    private float waitTime;
    //How long they should wait before moving to a new waypoint
    public float startWaitTime;

    //The projectile is what the enemy will be shooting
    public GameObject projectile; 
    public Transform player;

    //The array to contain the waypoints that the enemy needs to move to
    public Transform[] moveSpots;
    private int randomSpot;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerCharacter").transform;
        timeBtwShots = startTimeBtwShots;

        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {
        //If the player is in range of attackDistance then begin attacking, otherwise patrol
        if (Vector2.Distance(transform.position, player.position) <= attackDistance)
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
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
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }

            else
            {
                timeBtwShots -= Time.deltaTime;
            }

        }

        else
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }
}
