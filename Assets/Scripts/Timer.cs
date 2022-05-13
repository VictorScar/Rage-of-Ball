using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float secondCount;
    public float seconds;
    public float minutes;
    public bool timerActive;
    public string time;
    public Text timerText;
    void Start()
    {
       secondCount = 0; 
       minutes =0;
       
    }

    void Update()
    {
        time = String.Format("{0:00}", minutes) + ": " + String.Format("{0:00}", seconds);
        timerText.text = ("Time: " + time);
        if (timerActive)
        {
            secondCount+=Time.deltaTime;
            if (secondCount >= 60)
            {
                minutes++;
                secondCount = 0;
            }
            seconds = Mathf.Round(secondCount);
            
           
        }

      

    }
}
