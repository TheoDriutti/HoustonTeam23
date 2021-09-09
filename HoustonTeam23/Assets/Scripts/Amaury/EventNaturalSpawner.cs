using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventNaturalSpawner : MonoBehaviour
{

    public List<Event> naturalEvents;

    public Event currentEvent;
    private Event lastEvent;

    public bool spawn;
    public float timeMin;
    public float timeMax;

    private float timer, time;

    public EventManager manager;

    void Update()
    {
        if (spawn)
        {
            int rand = Random.Range(0, naturalEvents.Count);
            time = Random.Range(timeMin, timeMax);
            currentEvent = naturalEvents[rand];

            if (lastEvent != null && lastEvent.id == currentEvent.id) return;

            manager.ui.DisplayIcon(currentEvent);
            lastEvent = currentEvent;
            spawn = false;
        }
        else
        {
            if (!currentEvent.value)
            {
                timer += Time.deltaTime;
                if (timer >= time - 2f) // PAtch quand tu collisionnes et que c deja entrain de flash & désactiver la fin de l'image a la fin
                    manager.ui.Flash();

                if (timer >= time)
                {
                    currentEvent.value = true;
                    timer = 0f;
                    Debug.Log("Event " + currentEvent.name + " activated");
                }
            }
        }
    }
}
