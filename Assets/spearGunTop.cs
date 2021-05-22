using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spearGunTop : MonoBehaviour
{
    [SerializeField] GameObject spear;
    public float force = 10;
    Rigidbody rigidbody;
    AudioSource audiosource;
    [SerializeField] AudioClip arrowSound;

    void Start()
    {
        rigidbody = spear.GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rigidbody.AddForce(-Vector3.up * force);
            if (!audiosource.isPlaying)
            {
                audiosource.PlayOneShot(arrowSound);
            }
        }
    }
}
