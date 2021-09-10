using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCollisionSpawner : MonoBehaviour
{
    [Header("Explosion/Smoke")]
    public GameObject[] explosion;
    public GameObject[] smoke;
    public Transform explosionPos;
    public int index = 0;

    [Header("Events")]
    public List<Event> collisionEvents;

    private Event currentEvent, lastEvent;
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
        if (BeginAnimation.instance.runAnim) return;

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
            if (!playerController.hurt)
            {
                playerController.hurt = true;

                scoreCounter.streakMultiplier = 0;
                ShipHealth.instance.TakeDamage(1);
                // impactSound.Play();

                if (ShipHealth.instance.currentHealth == 0)
                    EventAudio.instance.explosion.Play();



                StartCoroutine(CameraShake.instance.Shake(.15f, .4f));

                Transform Pos = explosionPos.GetChild(Random.Range(0, explosionPos.childCount));
                explosion[index].transform.position = Pos.transform.position;
                explosion[index].SetActive(true);

                if (ShipHealth.instance.currentHealth <= 2)
                {
                    Transform SmokePos = explosionPos.GetChild(Random.Range(0, explosionPos.childCount));
                    smoke[index].transform.position = Pos.transform.position;
                    smoke[index].SetActive(true);
                    EventAudio.instance.impactLowHealth.Play();
                }
                else
                {
                    EventAudio.instance.impactFullHealth.Play();
                }
                index++;



                collider.GetComponent<ObstacleMovement>().enabled = false;
                collider.transform.localPosition = Vector3.zero;

                if (currentEvent != null && currentEvent.value) currentEvent.value = false;

                if (currentEvent != null && currentEvent.spawner.currentEvent != null) currentEvent.spawner.currentEvent.value = false;

                RandomEvent();

                if (currentEvent != null && lastEvent != null)
                {
                    while (currentEvent.id == lastEvent.id)
                    {
                        RandomEvent();
                    }
                }

                currentEvent.value = true;
                lastEvent = currentEvent;
                manager.ui.DisplayIcon(currentEvent, true);
                Debug.Log("Event " + currentEvent.name + " activated");

            }
        }

        if (collider.gameObject.tag == "BlackHole")
        {
            if (!playerController.hurt)
                ShipHealth.instance.TakeDamage(5);

        }
    }

    private void RandomEvent()
    {
        int rand = Random.Range(0, 100);
        if (rand >= 0 && rand < 33)  // premier event 
            currentEvent = collisionEvents[0];
        else if (rand >= 33 && rand < 67)  // deuxieme event
            currentEvent = collisionEvents[1];
        else if (rand >= 67)  // troisieme event
            currentEvent = collisionEvents[2];
        //else  // quatrieme event
        //    currentEvent = collisionEvents[3];
    }

}
