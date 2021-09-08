using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ObstacleSpeedConfig", order = 1)]
public class ObstacleSpeedConfig : ScriptableObject
{
    public float speed;
    public float speedVariation;
    public float angularSpeed;
    public float angularSpeedVariation;
}
