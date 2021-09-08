using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public ObstacleSpeedConfig config;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(config.angularSpeed * Time.deltaTime, config.angularSpeed * Time.deltaTime, config.angularSpeed * Time.deltaTime);
        transform.Translate(-Vector3.forward * config.speed * Time.deltaTime, Space.World);

        if (Camera.main.transform.position.z > transform.position.z)
        {
            this.enabled = false;
            transform.localPosition = Vector3.zero;
        }
    }
}
