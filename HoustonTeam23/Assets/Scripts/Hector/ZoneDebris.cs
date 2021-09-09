using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDebris : MonoBehaviour
{
    private ObstacleMovement moveScript;


    private void Start()
    {
        moveScript = GetComponent<ObstacleMovement>();
    }

    private void Update()
    {
        if (!moveScript.enabled)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(.15f, .4f));
        }
    }
}
