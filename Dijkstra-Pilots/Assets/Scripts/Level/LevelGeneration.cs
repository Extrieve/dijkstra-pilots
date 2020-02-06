using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Takes tile prefabs and places them in an order based on type.
 * Calls to other generators like EnemyGenerator or ItemGenerator
 */

public class LevelGeneration : MonoBehaviour
{
    public List<GameObject> normalTileSets = new List<GameObject>();

    //tile sets that have openings
    public List<GameObject> orTileSets = new List<GameObject>();
    public List<GameObject> olTileSets = new List<GameObject>();
    public List<GameObject> otTileSets = new List<GameObject>();
    public List<GameObject> obTileSets = new List<GameObject>();

    public List<GameObject> bossTileSets = new List<GameObject>();

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

        GenerateNewTiles();

        totalAvailableTiles = activeTileSets.Count;
        
        //Should not be called here. Call should be made from the game manager on level start
        GenerateLevel();
        iGen.GenerateNewItems();
        eGen.GenerateNewEnemies();
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

        for (int i = 0; i < orTileSets.Count; i++)
        {
            randomIndex = Random.Range(0, orTileSets.Count);

            activeTileSets.Add(Instantiate(orTileSets[randomIndex] as GameObject, envObjectsParent.transform));
        }

        for (int i = 0; i < olTileSets.Count; i++)
        {
            randomIndex = Random.Range(0, olTileSets.Count);

            activeTileSets.Add(Instantiate(olTileSets[randomIndex] as GameObject, envObjectsParent.transform));
        }

        for (int i = 0; i < otTileSets.Count; i++)
        {
            randomIndex = Random.Range(0, otTileSets.Count);

            activeTileSets.Add(Instantiate(otTileSets[randomIndex] as GameObject, envObjectsParent.transform));
        }

        for (int i = 0; i < obTileSets.Count; i++)
        {
            randomIndex = Random.Range(0, obTileSets.Count);

            activeTileSets.Add(Instantiate(obTileSets[randomIndex] as GameObject, envObjectsParent.transform));
        }

        for (int i = 0; i < bossTileSets.Count; i++)
        {
            randomIndex = Random.Range(0, bossTileSets.Count);

            activeTileSets.Add(Instantiate(bossTileSets[randomIndex] as GameObject, envObjectsParent.transform));
        }
    }
}
