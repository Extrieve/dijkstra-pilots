using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameManager GameManager;
    private GameObject levelCompleteScreen;
    //public GameObject levelCompletePanel;

    private void Start()
    {
        levelCompleteScreen = ReferenceHandler.GetObject(4);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){ // Only triggers when the player interacts with the object
        levelCompleteScreen.SetActive(true);   
         Debug.Log("Level Complete");
        }
        
        //GameManager.CompleteLevel();
        //GameManager.Reset();
    }
}
