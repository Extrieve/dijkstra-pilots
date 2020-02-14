using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Takes tile prefabs and places them in an order based on type.
 * Calls to other generators like EnemyGenerator or ItemGenerator
 */

public class LevelGeneration : MonoBehaviour
{
    //tile sets that have openings
    public List<GameObject> tileSets = new List<GameObject>();

    public GameObject hallConnector;

    private List<GameObject> activeTileSets = new List<GameObject>();

    private bool bossLevel = false;
    private int numberOfTiles = 1;
    private int currentLevel = 0;
    private int totalAvailableTiles = 0;

    private GameObject envObjectsParent;

    private ItemGeneration iGen;
    private EnemyGeneration eGen;

    private void Awake()
    {
        envObjectsParent = GameObject.Find("EnvObjects");
        iGen = GetComponent<ItemGeneration>();
        eGen = GetComponent<EnemyGeneration>();

        //GenerateNewTiles();

        totalAvailableTiles = activeTileSets.Count;
        
        //Should not be called here. Call should be made from the game manager on level start
        //GenerateLevel();
        //iGen.GenerateNewItems();
        //eGen.GenerateNewEnemies();
    }

    public void GenerateLevel() //called from game manager to create level at game start
    {
        //increment the number of tiles for every level after the first one
        for (int i = 0; i < currentLevel; i++)
        {
            numberOfTiles++;
        }

        //if the current level count is a divisor of 10, this is a boss level
        if (currentLevel % 10 == 0)
            bossLevel = true;
        else
            bossLevel = false;


        if(!bossLevel)
        {
            //generate a new level that does not have a boss room
        }
        else
        {
            //generate a new level that has a boss room
        }

        Debug.Log("Level gen complete");
    }

    public void GenerateNewTiles() //creates new tiles that are stored for later use
    {
        int randomIndex;

        for (int i = 0; i < tileSets.Count; i++)
        {
            randomIndex = Random.Range(0, tileSets.Count);

            activeTileSets.Add(Instantiate(tileSets[randomIndex] as GameObject, envObjectsParent.transform));
        }
    }
}
