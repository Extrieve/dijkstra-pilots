using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel_LC : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("Next Level from Level Complete Screen");
        ReferenceHandler.GetObject(5).GetComponent<GameManager>().GenerateNextLevel();
        gameObject.GetComponentInParent<Canvas>().gameObject.SetActive(false);
    }
}
