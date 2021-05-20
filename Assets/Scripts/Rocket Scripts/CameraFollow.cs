using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject rocket;
    Rigidbody rb;

    float rocketZ;
    float rocketY;

    Scene scene;
    int sceneInt;

    float camZ;

    Transform rocketTransform;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneInt = scene.buildIndex;
    }

    void Update()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rocketTransform = rocket.GetComponent<Transform>();
        rocketZ = rocketTransform.position.z;
        camZ = transform.position.z;

        if (sceneInt == 1)
        {
            tutorialSettings();
        }

        if (sceneInt == 3)
        {
            underwaterSettings();
        }

        else
        {
            standardSettings();
        }

        void tutorialSettings()
        {
            if (rocketTransform.position.y > 30f)
            {
                transform.position = (rocketTransform.position + new Vector3(80f, 15f));
            }
            else
            {
                
                transform.position = (new Vector3(80f, 45f, rocketZ));
            }
        }

        void standardSettings()
        {
            transform.position = rocketTransform.position + new Vector3(80f, 15f);
        }

        void underwaterSettings()
        {
            if (rocketTransform.position.y > 500f)
            {
                transform.position = (rocketTransform.position + new Vector3(80f, 15f));
            }
            else
            {

                transform.position = (new Vector3(80f, 45f, rocketZ));
            }
        }
    }
}
