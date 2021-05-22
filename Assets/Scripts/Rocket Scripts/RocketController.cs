using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour
{
    [SerializeField] float rcsThrust = 300;
    [SerializeField] float mainThrust = 1200;
    [SerializeField] float levelLoadDelay = 1f;

    [SerializeField] AudioClip mainEngineSound;
    [SerializeField] AudioClip rewardSound;
    [SerializeField] AudioClip deathSound;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem rewardParticles;
    [SerializeField] ParticleSystem deathParticles;

    Rigidbody rigidbody;
    AudioSource audio_source;
    Scene scene;

    int sceneInt;
    enum State { Alive, Dying, Transcending };
    [SerializeField] State state = State.Alive;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audio_source = GetComponent<AudioSource>();
        sceneInt = scene.buildIndex;
    }

    void Update()
    {
        if (state == State.Alive)
        {
            RespondToThrustInput();
            RespondToRotateInput();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("OK");
                break;
            case "Player":
                print("OK");
                break;
            case "Start":
                print("Start");
                rigidbody.freezeRotation = false;
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartDeathSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        print("Hit Finish");
        audio_source.Stop();
        state = State.Transcending;
        audio_source.PlayOneShot(rewardSound);
        rewardParticles.Play();
        Invoke("LoadNextScene", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        print("Dead");
        audio_source.Stop();
        state = State.Dying;
        audio_source.PlayOneShot(deathSound);
        deathParticles.Play();
        Invoke("LoadFirstLevel", levelLoadDelay);
    }

    private void LoadFirstLevel()
    {
        deathParticles.Stop();
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        state = State.Alive;
    }

    private void LoadNextScene()
    {
        if ((sceneInt == 3) == false)
        {
            rewardParticles.Stop();
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene + 1);
        }
    }
    private void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust();
        }
        else
        {
            audio_source.Stop();
            mainEngineParticles.Stop();
        }

    }

    private void ApplyThrust()
    {
        float thrustThisFrame = mainThrust * Time.deltaTime;
        rigidbody.AddRelativeForce(Vector3.up * thrustThisFrame);

        if (!audio_source.isPlaying && state == State.Alive)
        {
            audio_source.PlayOneShot(mainEngineSound);
            mainEngineParticles.Play();
        }
    }

    private void RespondToRotateInput()
    {
        rigidbody.freezeRotation = true;
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.right * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.right * rotationThisFrame);
        }

        rigidbody.freezeRotation = false;
    }
}
