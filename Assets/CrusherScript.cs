using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherScript : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip crusherSound;
    [SerializeField] GameObject crusher;
    [SerializeField] float laserFrequency = 10f;
    [SerializeField] float laserTime;
    [SerializeField] float wait;
    Animator animator;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (laserTime <= 0f)
        {
            wait += 1f;
            enableLaser();
            laserTime += laserFrequency;

        }

        else if (laserTime > 0f && wait <= 0f)
        {
            disableLaser();
            laserTime -= Time.deltaTime;
        }

        if (wait >= 0f)
        {
            wait -= Time.deltaTime;
        }
    }

    void enableLaser()
    {
        animator.SetBool("triggerCrush", true);
        audioSource.PlayOneShot(crusherSound);
    }

    void disableLaser()
    {
        animator.SetBool("triggerCrush", false);
        print("do nothing");
    }
}
