using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEvent : Event
{
    public float amplifier;
    public float maxSpeedTimer;

    bool speeding = false;
    float speedTimer;
    float[] baseSpeeds;

    // Faire une fonction OnFinish qui sexecute a la fin de mon event

    public override void Update()
    {
        base.Update();

        if (value)
        {
            if (speedTimer <= maxSpeedTimer && !speeding)
            {
                speedTimer += Time.deltaTime;

                foreach (GameObject ast in GameObject.FindGameObjectsWithTag("Rock"))
                {
                    ast.GetComponent<ObstacleMovement>().speed = ast.GetComponent<ObstacleMovement>().baseSpeed + amplifier * speedTimer / maxSpeedTimer;
                }
                foreach (GameObject ast in GameObject.FindGameObjectsWithTag("Big Rock"))
                {
                    ast.GetComponent<ObstacleMovement>().speed = ast.GetComponent<ObstacleMovement>().baseSpeed + amplifier * speedTimer / maxSpeedTimer;
                }
                foreach (GameObject ast in GameObject.FindGameObjectsWithTag("Debris"))
                {
                    ast.GetComponent<ObstacleMovement>().speed = ast.GetComponent<ObstacleMovement>().baseSpeed + amplifier * speedTimer / maxSpeedTimer;
                }
            }
            else
            {
                speeding = true;
            }

        }
        else
        {
            if (speeding)
            {
                speeding = false;
                speedTimer = 0f;
                foreach (GameObject ast in GameObject.FindGameObjectsWithTag("Rock"))
                {
                    ast.GetComponent<ObstacleMovement>().speed = ast.GetComponent<ObstacleMovement>().baseSpeed;
                }
                foreach (GameObject ast in GameObject.FindGameObjectsWithTag("Big Rock"))
                {
                    ast.GetComponent<ObstacleMovement>().speed = ast.GetComponent<ObstacleMovement>().baseSpeed;
                }
                foreach (GameObject ast in GameObject.FindGameObjectsWithTag("Debris"))
                {
                    ast.GetComponent<ObstacleMovement>().speed = ast.GetComponent<ObstacleMovement>().baseSpeed;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            value = true;
        }
    }
}

