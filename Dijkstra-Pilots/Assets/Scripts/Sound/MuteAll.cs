using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAll : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(GetComponent<AudioSource>().mute)
            {
                GetComponent<AudioSource>().mute = false;
                AudioListener.volume = 1f;
            }
            else
            {
                GetComponent<AudioSource>().mute = true;
                AudioListener.volume = 0f;
            }
        }
    }

}
