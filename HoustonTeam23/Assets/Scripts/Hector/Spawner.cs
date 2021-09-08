using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform rockStorage;
    public GameObject bigFatRock;

    public bool isThereBigRock = false;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTimeBtwSpawn;
    public float minTimeBtwSpawn = 2;


    void Start()
    {
        timeBtwSpawn = startTimeBtwSpawn;
    }


    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            SimpleRockActivation();
            int rand = Random.Range(0, 6);
            if (rand == 4 && isThereBigRock == false)
            {
                BigRockActivation();
            }
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTimeBtwSpawn)
            {
                startTimeBtwSpawn -= decreaseTimeBtwSpawn;
            }

        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

    public void SimpleRockActivation()
    {
        for (int i = Random.Range(1, 7); i >= 0; i--)
        {
            Vector3 spawnPosition = transform.position;
            spawnPosition.x += Random.Range(-30, 30);
            spawnPosition.y = Random.Range(-10, 10);
            spawnPosition.z = transform.position.z;
            Transform rock = rockStorage.GetChild(0);
            rock.SetAsLastSibling();
            rock.transform.position = spawnPosition;
        }
    }

    public void BigRockActivation()
    {
        Vector3 spawnPosition = transform.position;
        spawnPosition.x += Random.Range(-30, 10);
        spawnPosition.y = Random.Range(0, 10);
        spawnPosition.z = transform.position.z;
        GameObject bigRock = bigFatRock;
        bigFatRock.transform.position = spawnPosition;
        isThereBigRock = true;
    }

}