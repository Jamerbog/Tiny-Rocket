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

        if (sceneInt == 1)
        {
            tutorialSettings();
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
                rocketZ = rocketTransform.position.z;
                transform.position = (new Vector3(80f, 45f, rocketZ));
            }
        }

        void standardSettings()
        {
            if ((rocketTransform.position.y > 27f) || (rocketTransform.position.z > 0f) && !(rocketTransform.position.y > 27f))
            {
                if (rocketTransform.position.z > 0f)
                {
                    transform.position = (rocketTransform.position + new Vector3(80f, 15f));
                }
                else
                {
                    rocketY = rocketTransform.position.y + 15f;
                    transform.position = new Vector3(80f, rocketY);
                }
            }
        }
    }
}
