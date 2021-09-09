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

    public virtual void Update()
    {
        Debug.Log("lol: " + this);
        if (value)
        {
            Debug.Log("enter");
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
