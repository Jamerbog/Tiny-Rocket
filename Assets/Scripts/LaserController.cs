using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip electricalBuzz;
    [SerializeField] GameObject laserBeam;
    [SerializeField] float laserFrequency = 10f;
    [SerializeField] float laserTime;
    [SerializeField] float wait;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        laserBeam.SetActive(true);
        audioSource.PlayOneShot(electricalBuzz);
    }

    void disableLaser()
    {
        laserBeam.SetActive(false);
    }
}
