using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameManager GameManager;
    private GameObject levelCompleteText;

    private void Start()
    {
        levelCompleteText = ReferenceHandler.GetObject(4);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        levelCompleteText.SetActive(true);
        Debug.Log("Level Complete");
        //GameManager.CompleteLevel();
        //GameManager.Reset();
    }
}
