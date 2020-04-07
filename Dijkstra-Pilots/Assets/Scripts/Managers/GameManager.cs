using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ReferenceManager refMgr;
    LevelGeneration levelGen;

    private void Awake()
    {
        refMgr = GetComponent<ReferenceManager>();
        levelGen = GetComponent<LevelGeneration>();
        refMgr.SendReferences();
    }

    private void Start()
    {
        GenerateNextLevel();
    }

    public void GenerateNextLevel()
    {
        levelGen.CreateNewLevel();
        ReferenceHandler.GetObject(1).GetComponent<PlayerMovement>().ResetPosition();
    }
}
