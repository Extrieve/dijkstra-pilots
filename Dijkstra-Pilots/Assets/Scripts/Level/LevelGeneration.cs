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
    private int levelTileCount = 2;
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
            int tileCount = currentLevel + tileIncreasePerLevel;
            GameObject previousTile = null;
            float previousXPos = 0, previousYPos = 0;

            for (int i = 0; i < tileCount; i++)
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
                    if(previousTile.name.Contains("Tile_T_"))
                    {
                        xPos = previousXPos;
                        yPos = previousYPos + tbTileDistance;
                        currentTile.transform.position = new Vector3(xPos, yPos);
                    }
                    else if (previousTile.name.Contains("Tile_L_"))
                    {
                        xPos = previousXPos - lrTileDistance;
                        yPos = previousYPos;
                        currentTile.transform.position = new Vector3(xPos, yPos);
                    }
                    else if (previousTile.name.Contains("Tile_R_"))
                    {
                        xPos = previousXPos + lrTileDistance;
                        yPos = previousYPos;
                        currentTile.transform.position = new Vector3(xPos, yPos);
                    }
                    else if (previousTile.name.Contains("Tile_B_"))
                    {
                        xPos = previousXPos;
                        yPos = previousYPos - tbTileDistance;
                        currentTile.transform.position = new Vector3(xPos, yPos);
                    }
                    else if (previousTile.name.Contains("Tile_TB_"))
                    {
                        int upOrDown = Random.Range(0, 2);

                        if(upOrDown == 0)
                            yPos = previousYPos + tbTileDistance;
                        else
                            yPos = previousYPos - tbTileDistance;

                        xPos = previousXPos;
                        currentTile.transform.position = new Vector3(xPos, yPos);
                    }
                    else if (previousTile.name.Contains("Tile_TLB_"))
                    {
                        int upLeftorDown = Random.Range(0, 3);

                        if (upLeftorDown == 0)
                        {
                            xPos = previousXPos;
                            yPos = previousYPos + tbTileDistance;
                        }
                        else if (upLeftorDown == 1)
                        {
                            xPos = previousXPos - lrTileDistance;
                            yPos = previousYPos;
                        }
                        else if (upLeftorDown == 2)
                        {
                            xPos = previousXPos;
                            yPos = previousYPos - tbTileDistance;
                        }

                        currentTile.transform.position = new Vector3(xPos, yPos);
                    }
                    else if (previousTile.name.Contains("Tile_TRB_"))
                    {
                        int upRightorDown = Random.Range(0, 3);

                        if (upRightorDown == 0)
                        {
                            xPos = previousXPos;
                            yPos = previousYPos + tbTileDistance;
                        }
                        else if (upRightorDown == 1)
                        {
                            xPos = previousXPos + lrTileDistance;
                            yPos = previousYPos;
                        }
                        else if (upRightorDown == 2)
                        {
                            xPos = previousXPos;
                            yPos = previousYPos - tbTileDistance;
                        }

                        currentTile.transform.position = new Vector3(xPos, yPos);
                    }
                    else if (previousTile.name.Contains("Tile_A_"))
                    {
                        int upRightLeftorDown = Random.Range(0, 4);

                        if (upRightLeftorDown == 0)
                        {
                            xPos = previousXPos;
                            yPos = previousYPos + tbTileDistance;
                        }
                        else if (upRightLeftorDown == 1)
                        {
                            xPos = previousXPos + lrTileDistance;
                            yPos = previousYPos;
                        }
                        else if (upRightLeftorDown == 2)
                        {
                            xPos = previousXPos - lrTileDistance;
                            yPos = previousYPos;
                        }
                        else if (upRightLeftorDown == 3)
                        {
                            xPos = previousXPos;
                            yPos = previousYPos - tbTileDistance;
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

        Debug.Log("Level gen complete");
    }

    public void GenerateNewTiles()
    {
        activeTileSets.Clear();

        int randomIndex;

        //based on the current level that the tiles are being generated for, pick a set of tiles that will be able to connect
        randomIndex = Random.Range(0, tileSets.Count);
        GameObject newTile;

        activeTileSets.Add(newTile = Instantiate(tileSets[randomIndex] as GameObject, envObjectsParent.transform));
        newTile.SetActive(false);

        string newTileName = newTile.name;

        for (int i = 0; i < levelTileCount; i++)
        {
            if (newTileName.Contains("Tile_T_"))
            {
                GameObject connectingTile;
                int randomTile;
                do
                {
                    randomTile = Random.Range(0, tileSets.Count);
                    connectingTile = tileSets[randomTile];
                }
                while (!connectingTile.name.Contains("Tile_B"));

                GameObject createdTile;

                activeTileSets.Add(Instantiate(createdTile = connectingTile as GameObject, envObjectsParent.transform));
                createdTile.SetActive(false);

                newTileName = createdTile.name;
            }
            else if (newTileName.Contains("Tile_L_"))
            {
                GameObject connectingTile;
                int randomTile;
                do
                {
                    randomTile = Random.Range(0, tileSets.Count);
                    connectingTile = tileSets[randomTile];
                }
                while (!connectingTile.name.Contains("Tile_R"));

                GameObject createdTile;

                activeTileSets.Add(Instantiate(createdTile = connectingTile as GameObject, envObjectsParent.transform));
                createdTile.SetActive(false);

                newTileName = createdTile.name;
            }
            else if (newTileName.Contains("Tile_R_"))
            {
                GameObject connectingTile;
                int randomTile;
                do
                {
                    randomTile = Random.Range(0, tileSets.Count);
                    connectingTile = tileSets[randomTile];
                }
                while (!connectingTile.name.Contains("Tile_L"));

                GameObject createdTile;

                activeTileSets.Add(Instantiate(createdTile = connectingTile as GameObject, envObjectsParent.transform));
                createdTile.SetActive(false);

                newTileName = createdTile.name;
            }
            else if (newTileName.Contains("Tile_B_"))
            {
                GameObject connectingTile;
                int randomTile;
                do
                {
                    randomTile = Random.Range(0, tileSets.Count);
                    connectingTile = tileSets[randomTile];
                }
                while (!connectingTile.name.Contains("Tile_T"));

                GameObject createdTile;

                activeTileSets.Add(Instantiate(createdTile = connectingTile as GameObject, envObjectsParent.transform));
                createdTile.SetActive(false);

                newTileName = createdTile.name;
            }
            else if (newTileName.Contains("Tile_TB_"))
            {
                GameObject connectingTile;
                int randomTile;
                do
                {
                    randomTile = Random.Range(0, tileSets.Count);
                    connectingTile = tileSets[randomTile];
                }
                while (!connectingTile.name.Contains("Tile_B") && !connectingTile.name.Contains("Tile_T"));

                GameObject createdTile;

                activeTileSets.Add(Instantiate(createdTile = connectingTile as GameObject, envObjectsParent.transform));
                createdTile.SetActive(false);

                newTileName = createdTile.name;
            }
            else if (newTileName.Contains("Tile_TLB_"))
            {
                GameObject connectingTile;
                int randomTile;
                do
                {
                    randomTile = Random.Range(0, tileSets.Count);
                    connectingTile = tileSets[randomTile];
                }
                while (!connectingTile.name.Contains("Tile_B") && !connectingTile.name.Contains("Tile_T") && !connectingTile.name.Contains("Tile_R"));

                GameObject createdTile;

                activeTileSets.Add(Instantiate(createdTile = connectingTile as GameObject, envObjectsParent.transform));
                createdTile.SetActive(false);

                newTileName = createdTile.name;
            }
            else if (newTileName.Contains("Tile_TRB_"))
            {
                GameObject connectingTile;
                int randomTile;
                do
                {
                    randomTile = Random.Range(0, tileSets.Count);
                    connectingTile = tileSets[randomTile];
                }
                while (!connectingTile.name.Contains("Tile_B") && !connectingTile.name.Contains("Tile_T") && !connectingTile.name.Contains("Tile_L"));

                GameObject createdTile;

                activeTileSets.Add(Instantiate(createdTile = connectingTile as GameObject, envObjectsParent.transform));
                createdTile.SetActive(false);

                newTileName = createdTile.name;
            }
            else if (newTileName.Contains("Tile_A_"))
            {

                int randomTile = Random.Range(0, tileSets.Count);
                GameObject connectingTile = tileSets[randomTile];

                GameObject createdTile;

                activeTileSets.Add(Instantiate(createdTile = connectingTile as GameObject, envObjectsParent.transform));
                createdTile.SetActive(false);

                newTileName = createdTile.name;
            }
        }
    }
}
