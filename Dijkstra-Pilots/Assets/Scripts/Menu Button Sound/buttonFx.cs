using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFx : MonoBehaviour
{

    public AudioSource fX;
    public AudioClip buttonSound;
   
    public void ButtonSound()
    {
        fX.PlayOneShot(buttonSound);
    }
}
