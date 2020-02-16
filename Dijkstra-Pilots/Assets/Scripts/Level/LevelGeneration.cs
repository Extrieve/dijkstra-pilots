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
    private int currentLevel = 0;
    private int levelTileCount = 10;
    private int tbTileDistance = 15;
    private int lrTileDistance = 23;
    public int tileIncreasePerLevel;

    private GameObject envObjectsParent;

    private ItemGeneration iGen;
    private EnemyGeneration eGen;

    private void Awake()
    {
        envObjectsParent = GameObject.Find("EnvObjects");
        iGen = GetComponent<ItemGeneration>();
        eGen = GetComponent<EnemyGeneration>();

        GenerateNewTiles();
        
        //Should not be called here. Call should be made from the game manager on level start
        GenerateLevel();
        //iGen.GenerateNewItems();
        //eGen.GenerateNewEnemies();
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

            for (int i = 0; i < levelTileCount; i++)
            {
                float xPos = 0, yPos = 0;
                int randomTile = 0;

                do
                {
                    randomTile = Random.Range(0, activeTileSets.Count);
                }
                while (activeTileSets[randomTile].activeSelf);

                GameObject currentTile = activeTileSets[randomTile];
                currentTile.SetActive(true);

                if(previousTile == null)
                {
                    xPos = 0;
                    yPos = 0;
                    currentTile.transform.position = new Vector3(xPos, yPos);
                }
                else
                {
                    if (previousTile.name.Contains("Tile_T_")) //if the previous tile was a top connector
                    {
                        xPos = previousXPos;
                        yPos = previousYPos + tbTileDistance;
                        currentTile.transform.position = new Vector3(xPos, yPos);
                    }
                    else if (previousTile.name.Contains("Tile_L_")) //if the previous tile was a left connector
                    {
                        xPos = previousXPos - lrTileDistance;
                        yPos = previousYPos;
                        currentTile.transform.position = new Vector3(xPos, yPos);
                    }
                    else if (previousTile.name.Contains("Tile_R_")) //if the previous tile was a right connector
                    {
                        xPos = previousXPos + lrTileDistance;
                        yPos = previousYPos;
                        currentTile.transform.position = new Vector3(xPos, yPos);
                    }
                    else if (previousTile.name.Contains("Tile_B_")) //if the previous tile was a bottom connector
                    {
                        xPos = previousXPos;
                        yPos = previousYPos - tbTileDistance;
                        currentTile.transform.position = new Vector3(xPos, yPos);
                    }
                    else if (previousTile.name.Contains("Tile_TB_")) //if the previous tile was a top bottom connector
                    {
                        if (currentTile.name.Contains("Tile_T_"))
                        {
                            xPos = previousXPos;
                            yPos = previousYPos - tbTileDistance;
                        }
                        else if (currentTile.name.Contains("Tile_B_"))
                        {
                            xPos = previousXPos;
                            yPos = previousYPos + tbTileDistance;
                        }
                        else if (currentTile.name.Contains("Tile_TB_") || currentTile.name.Contains("Tile_TRB_") || currentTile.name.Contains("Tile_TLB_") || currentTile.name.Contains("Tile_A_"))
                        {
                            int randomPos = Random.Range(0, 2);
                            if (randomPos == 1)
                                yPos = previousYPos - tbTileDistance;
                            else
                                yPos = previousYPos + tbTileDistance;
                        }

                        xPos = previousXPos;
                        currentTile.transform.position = new Vector3(xPos, yPos);
                    }
                    else if (previousTile.name.Contains("Tile_TLB_")) //if the previous tile was a top left bottom connector
                    {
                        if (currentTile.name.Contains("Tile_R_"))
                        {
                            xPos = previousXPos - lrTileDistance;
                            yPos = previousYPos;
                        }
                        else if (currentTile.name.Contains("Tile_T_"))
                        {
                            xPos = previousXPos;
                            yPos = previousYPos - tbTileDistance;
                        }
                        else if (currentTile.name.Contains("Tile_B_"))
                        {
                            xPos = previousXPos;
                            yPos = previousYPos + tbTileDistance;
                        }
                        else if (currentTile.name.Contains("Tile_TB_"))
                        {
                            int randomPos = Random.Range(0, 2);
                            if (randomPos == 1)
                            {
                                xPos = previousXPos;
                                yPos = previousYPos - tbTileDistance;
                            }
                            else
                            {
                                xPos = previousXPos;
                                yPos = previousYPos + tbTileDistance;
                            }
                        }
                        else if (currentTile.name.Contains("Tile_TRB_"))
                        {
                            int randomPos = Random.Range(0, 3);
                            if (randomPos == 0)
                            {
                                xPos = previousXPos;
                                yPos = previousYPos - tbTileDistance;
                            }
                            else if (randomPos == 1)
                            {
                                xPos = previousXPos;
                                yPos = previousYPos + tbTileDistance;
                            }
                            else if (randomPos == 2)
                            {
                                xPos = previousXPos - lrTileDistance;
                                yPos = previousYPos;
                            }
                        }
                        else if (currentTile.name.Contains("Tile_TLB_"))
                        {
                            int randomPos = Random.Range(0, 2);
                            if (randomPos == 1)
                            {
                                xPos = previousXPos;
                                yPos = previousYPos - tbTileDistance;
                            }
                            else
                            {
                                xPos = previousXPos;
                                yPos = previousYPos + tbTileDistance;
                            }
                        }
                        else if (currentTile.name.Contains("Tile_A_"))
                        {
                            int randomPos = Random.Range(0, 4);
                            if (randomPos == 0)
                            {
                                xPos = previousXPos;
                                yPos = previousYPos - tbTileDistance;
                            }
                            else if (randomPos == 1)
                            {
                                xPos = previousXPos;
                                yPos = previousYPos + tbTileDistance;
                            }
                            else if (randomPos == 2)
                            {
                                xPos = previousXPos + lrTileDistance;
                                yPos = previousYPos;
                            }
                            else if (randomPos == 3)
                            {
                                xPos = previousXPos - lrTileDistance;
                                yPos = previousYPos;
                            }
                        }

                        currentTile.transform.position = new Vector3(xPos, yPos);
                    }
                    else if (previousTile.name.Contains("Tile_TRB_")) //if the previous tile was a top right bottom connector
                    {
                        if(currentTile.name.Contains("Tile_L_"))
                        {
                              xPos = previousXPos + lrTileDistance;
                              yPos = previousYPos;
                        }
                        else if (currentTile.name.Contains("Tile_T_"))
                        {
                              xPos = previousXPos;
                              yPos = previousYPos - tbTileDistance;
                        }
                        else if (currentTile.name.Contains("Tile_B_"))
                        {
                            xPos = previousXPos;
                            yPos = previousYPos + tbTileDistance;
                        }
                        else if (currentTile.name.Contains("Tile_TB_"))
                        {
                            int randomPos = Random.Range(0, 2);
                            if (randomPos == 1)
                            {
                                xPos = previousXPos;
                                yPos = previousYPos - tbTileDistance;
                            }
                            else
                            {
                                xPos = previousXPos;
                                yPos = previousYPos + tbTileDistance;
                            }
                        }
                        else if (currentTile.name.Contains("Tile_TRB_"))
                        {
                            int randomPos = Random.Range(0, 2);
                            if (randomPos == 1)
                            {
                                xPos = previousXPos;
                                yPos = previousYPos - tbTileDistance;
                            }
                            else
                            {
                                xPos = previousXPos;
                                yPos = previousYPos + tbTileDistance;
                            }
                        }
                        else if (currentTile.name.Contains("Tile_TLB_"))
                        {
                            int randomPos = Random.Range(0, 3);
                            if (randomPos == 0)
                            {
                                xPos = previousXPos;
                                yPos = previousYPos - tbTileDistance;
                            }
                            else if (randomPos == 1)
                            {
                                xPos = previousXPos;
                                yPos = previousYPos + tbTileDistance;
                            }
                            else if (randomPos == 2)
                            {
                                xPos = previousXPos + lrTileDistance;
                                yPos = previousYPos;
                            }
                        }
                        else if (currentTile.name.Contains("Tile_A_"))
                        {
                            int randomPos = Random.Range(0, 4);
                            if (randomPos == 0)
                            {
                                xPos = previousXPos;
                                yPos = previousYPos - tbTileDistance;
                            }
                            else if (randomPos == 1)
                            {
                                xPos = previousXPos;
                                yPos = previousYPos + tbTileDistance;
                            }
                            else if (randomPos == 2)
                            {
                                xPos = previousXPos + lrTileDistance;
                                yPos = previousYPos;
                            }
                            else if (randomPos == 3)
                            {
                                xPos = previousXPos - lrTileDistance;
                                yPos = previousYPos;
                            }
                        }

                        currentTile.transform.position = new Vector3(xPos, yPos);
                    }
                    else if (previousTile.name.Contains("Tile_A_")) //if the previous tile was an all connector
                    {
                        if (currentTile.name.Contains("Tile_R_"))
                        {
                            xPos = previousXPos - lrTileDistance;
                            yPos = previousYPos;
                        }
                        else if (currentTile.name.Contains("Tile_T_"))
                        {
                            xPos = previousXPos;
                            yPos = previousYPos - tbTileDistance;
                        }
                        else if (currentTile.name.Contains("Tile_B_"))
                        {
                            xPos = previousXPos;
                            yPos = previousYPos + tbTileDistance;
                        }
                        else if (currentTile.name.Contains("Tile_L_"))
                        {
                            xPos = previousXPos + lrTileDistance;
                            yPos = previousYPos;
                        }
                        else if(currentTile.name.Contains("Tile_TB_"))
                        {
                            int randomPos = Random.Range(0, 2);
                            if(randomPos == 1)
                            {
                                xPos = previousXPos;
                                yPos = previousYPos - tbTileDistance;
                            }
                            else
                            {
                                xPos = previousXPos;
                                yPos = previousYPos + tbTileDistance;
                            }
                        }
                        else if (currentTile.name.Contains("Tile_TLB_"))
                        {
                            int randomPos = Random.Range(0, 3);
                            if(randomPos == 0)
                            {
                                xPos = previousXPos;
                                yPos = previousYPos - tbTileDistance;
                            }
                            else if (randomPos == 1)
                            {
                                xPos = previousXPos;
                                yPos = previousYPos + tbTileDistance;
                            }
                            else if (randomPos == 2)
                            {
                                xPos = previousXPos + lrTileDistance;
                                yPos = previousYPos;
                            }
                        }
                        else if (currentTile.name.Contains("Tile_TRB_"))
                        {
                            int randomPos = Random.Range(0, 3);
                            if (randomPos == 0)
                            {
                                xPos = previousXPos;
                                yPos = previousYPos - tbTileDistance;
                            }
                            else if (randomPos == 1)
                            {
                                xPos = previousXPos;
                                yPos = previousYPos + tbTileDistance;
                            }
                            else if (randomPos == 2)
                            {
                                xPos = previousXPos - lrTileDistance;
                                yPos = previousYPos;
                            }
                        }

                        currentTile.transform.position = new Vector3(xPos, yPos);
                    }
                }

                previousTile = currentTile;
                previousXPos = currentTile.transform.position.x;
                previousYPos = currentTile.transform.position.y;
            }
        }
        else
        {
            //generate a new level that has a boss room
        }

        currentLevel++;
        levelTileCount += tileIncreasePerLevel;

        Debug.Log("Level gen complete");
    }

    public void GenerateNewTiles()
    {
        //clear the current tiles in prep for the next level's tiles
        activeTileSets.Clear();

        //choose a random index for the first tile
        int randomIndex;
        randomIndex = Random.Range(0, tileSets.Count);

        //create a var to hold the first tile
        GameObject newTile;

        //create and add the new tile to the active tiles list
        activeTileSets.Add(newTile = Instantiate(tileSets[randomIndex] as GameObject, envObjectsParent.transform));
        newTile.SetActive(false);

        //get the name of the first tile
        string newTileName = newTile.name;

        //create vars that will be used in the loop below
        GameObject createdTile = null;
        GameObject connectingTile = null;
        int randomTile;

        //for however many tiles are needed for the current level, find a tile that connects to the previous tile
        //the first run will look for a tile that connects to the first tile created above
        for (int i = 1; i < levelTileCount; i++)
        {
            if (newTileName.Contains("Tile_T_"))
            {
                do
                {
                    randomTile = Random.Range(0, tileSets.Count);
                    connectingTile = tileSets[randomTile];
                }
                while (!connectingTile.name.Contains("Tile_B_"));
            }
            else if (newTileName.Contains("Tile_L_"))
            {
                do
                {
                    randomTile = Random.Range(0, tileSets.Count);
                    connectingTile = tileSets[randomTile];
                }
                while (!connectingTile.name.Contains("Tile_R_"));
            }
            else if (newTileName.Contains("Tile_R_"))
            {
                do
                {
                    randomTile = Random.Range(0, tileSets.Count);
                    connectingTile = tileSets[randomTile];
                }
                while (!connectingTile.name.Contains("Tile_L_"));
            }
            else if (newTileName.Contains("Tile_B_"))
            {
                do
                {
                    randomTile = Random.Range(0, tileSets.Count);
                    connectingTile = tileSets[randomTile];
                }
                while (!connectingTile.name.Contains("Tile_T_"));
            }
            else if (newTileName.Contains("Tile_TB_"))
            {
                do
                {
                    randomTile = Random.Range(0, tileSets.Count);
                    connectingTile = tileSets[randomTile];
                }
                while (!connectingTile.name.Contains("Tile_B_") && !connectingTile.name.Contains("Tile_T_"));
            }
            else if (newTileName.Contains("Tile_TLB_"))
            {
                do
                {
                    randomTile = Random.Range(0, tileSets.Count);
                    connectingTile = tileSets[randomTile];
                }
                while (!connectingTile.name.Contains("Tile_B_") && !connectingTile.name.Contains("Tile_T_") && !connectingTile.name.Contains("Tile_R_"));
            }
            else if (newTileName.Contains("Tile_TRB_"))
            {
                do
                {
                    randomTile = Random.Range(0, tileSets.Count);
                    connectingTile = tileSets[randomTile];
                }
                while (!connectingTile.name.Contains("Tile_B_") && !connectingTile.name.Contains("Tile_T_") && !connectingTile.name.Contains("Tile_L_"));
            }
            else if (newTileName.Contains("Tile_A_"))
            {
                randomTile = Random.Range(0, tileSets.Count);
                connectingTile = tileSets[randomTile];
            }

            activeTileSets.Add(Instantiate(createdTile = connectingTile as GameObject, envObjectsParent.transform));
            createdTile.SetActive(false);
            newTileName = createdTile.name;
        }
    }
}
