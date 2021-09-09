using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCollisionSpawner : MonoBehaviour
{

    public List<Event> collisionEvents;

    private Event currentEvent;
    public EventManager manager;

    // Faire un lastEvent

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Rock" || collider.gameObject.tag == "Big Rock")
        {
            ShipHealth.instance.TakeDamage(1);
            StartCoroutine(CameraShake.instance.Shake(.15f, .4f));

            collider.GetComponent<ObstacleMovement>().enabled = false;
            collider.transform.localPosition = Vector3.zero;

            ScoreCounter.instance.dodge = 0;

            if (currentEvent != null && currentEvent.value) currentEvent.value = false;

            if (currentEvent != null && currentEvent.spawner.currentEvent != null) currentEvent.spawner.currentEvent.value = false;

            int rand = Random.Range(0, 100);
            if (rand >= 0 && rand < 33)  // premier event 
                currentEvent = collisionEvents[0];
            else if (rand >= 33 && rand < 67)  // deuxieme event
                currentEvent = collisionEvents[1];
            else if (rand >= 67)  // troisieme event
                currentEvent = collisionEvents[2];
            //else  // quatrieme event
            //    currentEvent = collisionEvents[3];

            //currentEvent.value = true;
            manager.ui.DisplayIcon(currentEvent,true);
            Debug.Log("Event " + currentEvent.name + " activated");
        }
    }
}
