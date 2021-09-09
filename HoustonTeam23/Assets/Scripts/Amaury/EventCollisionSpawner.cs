using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCollisionSpawner : MonoBehaviour
{
    [Header("Explosion/Smoke")]
    public GameObject explosion;
    public GameObject[] smoke;
    public Transform explosionPos;
    public int index = 0;

    [Header("Events")]
    public List<Event> collisionEvents;

    private Event currentEvent;
    public EventManager manager;

    private PlayerController playerController;
    private ScoreCounter scoreCounter;

    private float lastHitTime = -1f;
    private float lastMultipTime = -1f;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        scoreCounter = GetComponent<ScoreCounter>();
    }

    private void Start()
    {
        lastHitTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - lastHitTime > scoreCounter.streakInterval && Time.time - lastMultipTime > scoreCounter.streakInterval)
        {
            scoreCounter.streakMultiplier++;
            scoreCounter.UpdateFeedback();
            lastMultipTime = Time.time;

        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Rock" || collider.gameObject.tag == "Big Rock")
        {
            lastHitTime = Time.time;
            scoreCounter.streakMultiplier = 1;
            scoreCounter.UpdateFeedback();

            if (!playerController.hurt)
            {
                playerController.hurt = true;

                ShipHealth.instance.TakeDamage(1);

                StartCoroutine(CameraShake.instance.Shake(.15f, .4f));

                Transform Pos = explosionPos.GetChild(Random.Range(0, explosionPos.childCount));
                explosion.transform.position = Pos.transform.position;
                explosion.SetActive(true);
                Transform SmokePos = explosionPos.GetChild(Random.Range(0, explosionPos.childCount));
                smoke[index].transform.position = Pos.transform.position;
                smoke[index].SetActive(true);
                index++;

                collider.GetComponent<ObstacleMovement>().enabled = false;
                collider.transform.localPosition = Vector3.zero;

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

                currentEvent.value = true;
                manager.ui.DisplayIcon(currentEvent, true);
                Debug.Log("Event " + currentEvent.name + " activated");

            }
        }
    }
}
