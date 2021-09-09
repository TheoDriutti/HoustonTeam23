using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideDamage : MonoBehaviour
{
    public float duration;
    public float magnitude;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ShipHealth.instance.TakeDamage(1);
            StartCoroutine(CameraShake.instance.Shake(.10f, .1f));
            //Desactivé le script qui les font avancé + les remettre dans le pull et au bon transform
        }
    }
}
