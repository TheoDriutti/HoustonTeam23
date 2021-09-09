using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCollisionSpawner : MonoBehaviour {
    
    public List<Event> collisionEvents;

    private Event currentEvent;
    public EventManager manager;

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            int rand = Random.Range(0,100);

            if(currentEvent != null && currentEvent.value) currentEvent.value = false;

            if(currentEvent != null && currentEvent.spawner.currentEvent != null) currentEvent.spawner.currentEvent.value = false;

            if(rand >= 0 && rand < 35)  // premier event 
                currentEvent = collisionEvents[0];
            else if(rand >= 35 && rand < 70)  // deuxieme event
                currentEvent = collisionEvents[1];
            else if(rand >= 70 && rand < 90)  // troisieme event
                currentEvent = collisionEvents[2];
            else  // quatrieme event
                currentEvent = collisionEvents[3];
            
            currentEvent.value = true;
            manager.ui.DisplayIcon(currentEvent);
            Debug.Log("Event " + currentEvent.name + " activated");
        }
    }
}
