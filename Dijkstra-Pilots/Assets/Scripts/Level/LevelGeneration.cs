﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Takes tile prefabs and places them in an order based on type.
 * Calls to other generators like EnemyGenerator or ItemGenerator
 */

public class LevelGeneration : MonoBehaviour
{
    public List<GameObject> tileSets = new List<GameObject>();
    public List<GameObject> items = new List<GameObject>();

    public GameObject hallConnector;

    private List<GameObject> activeTileSets = new List<GameObject>();
    private List<int> directions = new List<int>();

    private bool bossLevel = false;
    private int currentLevel = 0;
    private int levelTileCount = 2;
    private int tbTileDistance = 15;
    private int lrTileDistance = 23;
    public int tileIncreasePerLevel;

    private GameObject envObjectsParent;

    private EnemyGeneration eGen;

    private void Awake()
    {
        envObjectsParent = GameObject.Find("EnvObjects");
        eGen = GetComponent<EnemyGeneration>();
    }

    public void CreateNewLevel()
    {
        GenerateNewTiles();
        GenerateLevel();
        eGen.GenerateNewEnemies();
    }

    public void GenerateLevel() //called from game manager to create level at game start
    {

        //if the current level count is a divisor of 10, this is a boss level
        if (currentLevel % 10 == 0 && currentLevel != 0)
            bossLevel = true;
        else
            bossLevel = false;

        if(!bossLevel)
        {
            //generate a new level that does not have a boss room
            GameObject previousTile = null;
            float previousXPos = 0, previousYPos = 0;

            for (int i = 0; i < activeTileSets.Count; i++)
            {
                float xPos = 0, yPos = 0;

                GameObject currentTile = activeTileSets[i];
                currentTile.SetActive(true);

                if(previousTile == null)
                {
                    xPos = 0;
                    yPos = 0;
                }
                else
                {
                    switch (directions[i])
                    {
                        case 0: //tile moves up
                            xPos = previousXPos;
                            yPos = previousYPos + tbTileDistance;
                            break;

                        case 1: //tile moves down
                            xPos = previousXPos;
                            yPos = previousYPos - tbTileDistance;
                            break;

                        case 2: //tile moves left
                            xPos = previousXPos - lrTileDistance;
                            yPos = previousYPos;
                            break;

                        case 3: //tile moves right
                            xPos = previousXPos + lrTileDistance;
                            yPos = previousYPos;
                            break;
                    }
                }

                currentTile.transform.position = new Vector3(xPos, yPos);
                currentTile.GetComponent<ItemGeneration>().GenerateNewItems(items);
                previousTile = currentTile;
                previousXPos = currentTile.transform.position.x;
                previousYPos = currentTile.transform.position.y;
            }
        }
        else
        {
            //generate a new level that has a boss room (not setup)
            GameObject previousTile = null;
            float previousXPos = 0, previousYPos = 0;

            for (int i = 0; i < activeTileSets.Count; i++)
            {
                float xPos = 0, yPos = 0;

                GameObject currentTile = activeTileSets[i];
                currentTile.SetActive(true);

                if (previousTile == null)
                {
                    xPos = 0;
                    yPos = 0;
                }
                else
                {
                    switch (directions[i])
                    {
                        case 0: //tile moves up
                            xPos = previousXPos;
                            yPos = previousYPos + tbTileDistance;
                            break;

                        case 1: //tile moves down
                            xPos = previousXPos;
                            yPos = previousYPos - tbTileDistance;
                            break;

                        case 2: //tile moves left
                            xPos = previousXPos - lrTileDistance;
                            yPos = previousYPos;
                            break;

                        case 3: //tile moves right
                            xPos = previousXPos + lrTileDistance;
                            yPos = previousYPos;
                            break;
                    }
                }

                currentTile.transform.position = new Vector3(xPos, yPos);
                previousTile = currentTile;
                previousXPos = currentTile.transform.position.x;
                previousYPos = currentTile.transform.position.y;
            }
        }

        currentLevel++;
        levelTileCount += tileIncreasePerLevel;

        Debug.Log("Level gen complete");
    }

    public void GenerateNewTiles()
    {
        //clear the current tiles in prep for the next level's tiles
        List<GameObject> tempTiles = activeTileSets;

        foreach (GameObject tile in tempTiles)
        {
            Destroy(tile);
        }

        activeTileSets.Clear();

        directions.Clear();
        int previousDirection = -1;
        GameObject currentTile;

        //set the path that the tiles will generate with
        for (int i = 0; i < levelTileCount; i++)
        {
            int randomDirection = Random.Range(0, 4); //0 up 1 down 2 left 3 right

            while((randomDirection == 0 && previousDirection == 1) || (randomDirection == 2 && previousDirection == 3) || (randomDirection == 1 && previousDirection == 0) || (randomDirection == 3 && previousDirection == 2))
            {
                randomDirection = Random.Range(0, 4);
            }

            directions.Add(randomDirection);

            previousDirection = randomDirection;
        }

        //for each direction choose a tile that will work with the previous tile
        for (int i = 0; i < directions.Count; i++)
        {
            switch(directions[i])
            {
                case 0:
                    for (int y = 0; y < tileSets.Count; y++)
                    {
                        int randomTile = Random.Range(0, tileSets.Count);

                        if (tileSets[randomTile].name.Contains("Tile_TB_") || tileSets[randomTile].name.Contains("Tile_TLB_") || tileSets[randomTile].name.Contains("Tile_TRB_") || tileSets[randomTile].name.Contains("Tile_A_"))
                        {
                            activeTileSets.Add(currentTile = Instantiate(tileSets[randomTile] as GameObject, envObjectsParent.transform));
                            currentTile.SetActive(false);
                            break;
                        }
                    }
                    break;
                case 1:
                    for (int y = 0; y < tileSets.Count; y++)
                    {
                        int randomTile = Random.Range(0, tileSets.Count);

                        if (tileSets[randomTile].name.Contains("Tile_TB_") || tileSets[randomTile].name.Contains("Tile_TLB_") || tileSets[randomTile].name.Contains("Tile_TRB_") || tileSets[randomTile].name.Contains("Tile_A_"))
                        {
                            activeTileSets.Add(currentTile = Instantiate(tileSets[randomTile] as GameObject, envObjectsParent.transform));
                            currentTile.SetActive(false);
                            break;
                        }
                    }
                    break;
                case 2:
                    for (int y = 0; y < tileSets.Count; y++)
                    {
                        int randomTile = Random.Range(0, tileSets.Count);

                        if (tileSets[randomTile].name.Contains("Tile_A_"))
                        {
                            activeTileSets.Add(currentTile = Instantiate(tileSets[randomTile] as GameObject, envObjectsParent.transform));
                            currentTile.SetActive(false);
                            break;
                        }
                    }
                    break;
                case 3:
                    for (int y = 0; y < tileSets.Count; y++)
                    {
                        int randomTile = Random.Range(0, tileSets.Count);

                        if (tileSets[randomTile].name.Contains("Tile_A_"))
                        {
                            activeTileSets.Add(currentTile = Instantiate(tileSets[randomTile] as GameObject, envObjectsParent.transform));
                            currentTile.SetActive(false);
                            break;
                        }
                    }
                    break;
            }
        }
    }
}
