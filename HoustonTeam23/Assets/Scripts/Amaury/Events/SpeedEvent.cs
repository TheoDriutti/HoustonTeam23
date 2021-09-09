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

    private void Start()
    {
        //baseSpeeds = new float[GameData.i.speedConfigs.Length];
        //for (int i = 0; i < GameData.i.speedConfigs.Length; i++)
        //{
        //    baseSpeeds[i] = GameData.i.speedConfigs[i].speed;
        //}
    }

    public override void Update()
    {
        base.Update();

        if (value)
        {
            if (speedTimer <= maxSpeedTimer)
            {
                speedTimer += Time.deltaTime;

                //foreach (ObstacleSpeedConfig config in GameData.i.speedConfigs)
                //{
                //    config.speed *= amplifier * speedTimer / maxSpeedTimer;
                //}
            }

        }
        else
        {
            speedTimer = 0f;

            //for (int i = 0; i < GameData.i.speedConfigs.Length; i++)
            //{
            //    GameData.i.speedConfigs[i].speed = baseSpeeds[i];
            //}
        }
    }
}

