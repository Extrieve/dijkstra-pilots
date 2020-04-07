using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneration : MonoBehaviour
{
    private List<GameObject> spawnPositions = new List<GameObject>();
    public GameObject levelEndPosition;

    public void GenerateNewItems(List<GameObject> items)
    {
        spawnPositions.Clear();

        foreach (Transform itemSpawn in gameObject.GetComponentsInChildren<Transform>())
        {
            if (itemSpawn.name.Contains("Item Spawn"))
            {
                spawnPositions.Add(itemSpawn.gameObject);
            }
        }

        int randomNumberOfItems = Random.Range(0, 3);

        for (int i = 0; i < randomNumberOfItems; i++)
        {
            int randomItem = Random.Range(0, items.Count);
            int randomSpawn = Random.Range(0, spawnPositions.Count);
            List<int> usedSpawns = new List<int>();

            while(usedSpawns.Contains(randomSpawn))
            {
                randomSpawn = Random.Range(0, spawnPositions.Count);
            }

            Instantiate(items[randomItem] as GameObject, spawnPositions[randomSpawn].transform);
            usedSpawns.Add(randomSpawn);
        }

        Debug.Log("Item gen complete");
    }

    public GameObject GetLevelEndPos()
    {
        return levelEndPosition;
    }

}
