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
        levelGen.CreateNewLevel();
    }
}
