using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDebris : MonoBehaviour
{
    public int speed;

    public GameObject debris;
    public CameraShake cameraShake;

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(cameraShake.Shake(.15f, .4f));
        }
    }
}
