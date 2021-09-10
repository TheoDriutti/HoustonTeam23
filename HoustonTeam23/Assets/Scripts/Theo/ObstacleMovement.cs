using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public ObstacleSpeedConfig config;

    public float speed;
    public float angularSpeed;
    public int id;

    public float baseSpeed;

    private void Awake()
    {
        speed = config.speed + Random.Range(-1, 1) * config.speedVariation;
        angularSpeed = config.angularSpeed + Random.Range(-1, 1) * config.angularSpeedVariation;

        baseSpeed = speed;
    }

    // Update is called once per frame  
    void Update()
    {
        if(BeginAnimation.instance.runAnim)
            return;
            
        transform.Rotate(angularSpeed * Time.deltaTime, angularSpeed * Time.deltaTime, angularSpeed * Time.deltaTime);
        transform.Translate(-Vector3.forward * speed * Time.deltaTime, Space.World);

        //local
        if (Camera.main.transform.position.z > transform.position.z)
        {
            this.enabled = false;
            transform.localPosition = Vector3.zero;
        }

        if (PlayerController.i.transform.position.z > transform.position.z)
        {
            //Debug.Log("changeAlpha");

            //Renderer r = GetComponent<Renderer>();
            //Color materialColor = r.material.color;
            //r.material.color = new Color(materialColor.r, materialColor.g, materialColor.b, 0.5f);
        }
    }
}
