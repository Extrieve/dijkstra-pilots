using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text TimerT;
    private float startTime;
    public static float t;
    
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString("00");
        string seconds = (t % 60).ToString("00");
        TimerT.text = minutes + ":" + seconds;
    }
}
