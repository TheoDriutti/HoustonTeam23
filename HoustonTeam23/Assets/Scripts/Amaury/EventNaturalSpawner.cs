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
                if (timer >= time - 2f)
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
