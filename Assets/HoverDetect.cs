using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoverDetect : MonoBehaviour
{
    public TextMeshPro text;

    public float timeHovering;

    public bool inZone = false;

    void Start()
    {
        text = text.GetComponent<TextMeshPro>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inZone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inZone = false;
        }
    }

    void Update()
    {
        if (inZone)
        {
            timeHovering += Time.deltaTime;
            text.enabled = true;
            text.text = string.Format("{0:#.00}", timeHovering);
        }
        else
        {
            timeHovering = 0;
            text.enabled = false;
        }
    }
}
