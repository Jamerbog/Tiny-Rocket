using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public static float timePassed;
    bool timerDisabled = false;
    [SerializeField] GameObject timeText;
    TextMeshProUGUI textToChange;
    float roundedTime;

    void Update()
    {
        if (!timerDisabled)
        {
            timePassed += Time.deltaTime;
            Debug.Log("current time: " + timePassed);
        }
    }

    public void stopTimer()
    {
        timerDisabled = true;
        textToChange = timeText.GetComponent<TextMeshProUGUI>();
        roundedTime = (float)Math.Round(timePassed, 2);
        textToChange.text = ("Your Time: " + TimeSpan.FromSeconds(timePassed).Minutes +"m " + TimeSpan.FromSeconds(timePassed).Seconds) + "s";
    }
}
