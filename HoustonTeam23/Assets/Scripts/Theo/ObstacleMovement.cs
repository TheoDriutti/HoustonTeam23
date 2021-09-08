using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public ObstacleSpeedConfig config;

    private float speed;
    private float angularSpeed;

    private void Awake()
    {
        speed = config.speed + Random.Range(-1, 1) * config.speedVariation;
        angularSpeed = config.speed + Random.Range(-1, 1) * config.angularSpeedVariation;
    }

    // Update is called once per frame  
    void Update()
    {
        transform.Rotate(angularSpeed * Time.deltaTime, angularSpeed * Time.deltaTime, angularSpeed * Time.deltaTime);
        transform.Translate(-Vector3.forward * speed * Time.deltaTime, Space.World);

        //local
        if (Camera.main.transform.position.z > transform.position.z)
        {
            this.enabled = false;
            transform.localPosition = Vector3.zero;
        }
    }
}
