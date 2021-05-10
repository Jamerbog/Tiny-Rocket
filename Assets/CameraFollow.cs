using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject rocket;
    Rigidbody rb;

    float rocketZ;
    float rocketY;
    Transform rocketTransform;
    void Update()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rocketTransform = rocket.GetComponent<Transform>();


        


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
