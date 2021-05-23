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

    AudioSource audioSource;

    [SerializeField] AudioClip rewardSound;

    [SerializeField] GameObject greenCircle;

    [SerializeField] GameObject barrier;

    [SerializeField] GameObject whiteCircle;

    bool completedHovering = false;

    void Start()
    {
        text = text.GetComponent<TextMeshPro>();
        audioSource = GetComponent<AudioSource>();
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
        if (inZone && completedHovering == false)
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

        if (inZone && timeHovering >= 10f && completedHovering == false)
        {
            audioSource.PlayOneShot(rewardSound);
            text.enabled = false;
            greenCircle.SetActive(true);
            whiteCircle.SetActive(false);
            completedHovering = true;
            Destroy(barrier);
        }
    }
}
