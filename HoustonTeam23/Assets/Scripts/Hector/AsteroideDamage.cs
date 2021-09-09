using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AsteroideDamage : MonoBehaviour
{
    public GameObject explosion;
    public Transform explosionPos;



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //ShipHealth.instance.TakeDamage(1);
            //StartCoroutine(CameraShake.instance.Shake(.10f, .1f));
            Transform Pos = explosionPos.GetChild(Random.Range(0, explosionPos.childCount));
            explosion.transform.position = Pos.transform.position;
            explosion.SetActive(true);
        }
    }

    public IEnumerator Exploooosion()
    {

        yield return new WaitForSeconds(1f);
        explosion.SetActive(false);
    }
}
