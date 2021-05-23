using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class getTime : MonoBehaviour
{
    public TextMeshPro text;
    [SerializeField] GameObject timerObject;
    float timeTaken;
    timer timer;

    void Start()
    {
        text = GetComponent<TextMeshPro>();
        timer = timerObject.GetComponent<timer>();
        timeTaken = timer.timePassed;
        text.text = ("Your Time: \n" + TimeSpan.FromSeconds(timeTaken).Minutes + "m " + TimeSpan.FromSeconds(timeTaken).Seconds) + "s";

    }

}
