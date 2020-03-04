using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameManager GameManager;

    private void OnTriggerEnter2D(Collider2D other) {
            Debug.Log("Level Complete");
        //GameManager.CompleteLevel();
      //  GameManager.Reset();
    }
}
