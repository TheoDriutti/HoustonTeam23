using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{

    public bool value;
    private float timer;
    public float maxTimer;
    public int percentage;
    //public int counter,maxCounter; // ne sert que pour un event 

    void Update()
    {
        if (value)
        {
            timer += Time.deltaTime;

            if (timer >= maxTimer)
            {
                timer = 0;
                value = false;
            }
        }
    }
}
