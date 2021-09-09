using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{

    public string name;
    public int id;
    public bool value;
    private float timer = 0f;
    public float maxTimer;
    public int percentage;
    public Sprite icon;
    public EventNaturalSpawner spawner;

    public virtual void Update()
    {
        if (value)
        {
            timer += Time.deltaTime;

            if (timer >= maxTimer)
            {
                timer = 0f;
                value = false;
                spawner.spawn = true;
            }
        }
    }
}
