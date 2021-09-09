using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{

    public string name;
    public int id;
    public bool value;
    public float timer;
    public float maxTimer;
    public int percentage;
    public Sprite icon;
    public EventNaturalSpawner spawner;

    void Update()
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
        else {
            spawner.manager.ui.DisplayIcon(this,false);
        }
    }
}
