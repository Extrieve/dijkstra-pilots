using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject enemyPrefab;

    private List<GameObject> activeEnemies = new List<GameObject>();

    public void GenerateNewEnemies()
    {
        //Called from LevelGeneration to create new enemies once the level is created

        Debug.Log("Enemy gen complete");
    }
}
