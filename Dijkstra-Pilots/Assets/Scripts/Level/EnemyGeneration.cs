using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    //private List<GameObject> activeEnemies = new List<GameObject>();
    private List<GameObject> spawnPositions = new List<GameObject>();

    public void GenerateEnemies(GameObject enemy)
    {
        spawnPositions.Clear();

        foreach (Transform enemySpawn in gameObject.GetComponentsInChildren<Transform>())
        {
            if (enemySpawn.name.Contains("Enemy Spawn"))
            {
                spawnPositions.Add(enemySpawn.gameObject);
            }
        }

        int randomNumberOfItems = Random.Range(0, 3);

        for (int i = 0; i < randomNumberOfItems; i++)
        {
            int randomSpawn = Random.Range(0, spawnPositions.Count);
            List<int> usedSpawns = new List<int>();

            while (usedSpawns.Contains(randomSpawn))
            {
                randomSpawn = Random.Range(0, spawnPositions.Count);
            }

            Instantiate(enemy as GameObject, spawnPositions[randomSpawn].transform);
            usedSpawns.Add(randomSpawn);
        }

        Debug.Log("Enemy gen complete");
    }
}
