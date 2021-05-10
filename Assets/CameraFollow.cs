using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject rocket;
    Rigidbody rb;


    float rocketY;
    Transform rocketTransform;
    void Update()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rocketTransform = rocket.GetComponent<Transform>();
        if (rocketTransform.position.z > 0f)
        {
            transform.position = (rocketTransform.position + new Vector3(80f, 12f));
        }
        else
        {
            rocketY = rocketTransform.position.y + 12f;
            transform.position = new Vector3(80f, rocketY);
        }
    }
}
