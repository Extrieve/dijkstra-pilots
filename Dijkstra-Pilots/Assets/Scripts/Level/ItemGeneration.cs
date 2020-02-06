using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneration : MonoBehaviour
{
    public List<GameObject> itemPrefabs = new List<GameObject>();

    private List<GameObject> activeItems = new List<GameObject>();

    public void GenerateNewItems()
    {
        //called from LevelGeneration to create new items once the level is created

        Debug.Log("Item gen complete");
    }
}
