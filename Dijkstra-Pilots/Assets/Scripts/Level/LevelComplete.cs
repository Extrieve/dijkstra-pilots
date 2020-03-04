using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other) {
            Debug.Log("Level Complete");
        //GameManager.CompleteLevel();
      //  GameManager.Reset();
    }
}

