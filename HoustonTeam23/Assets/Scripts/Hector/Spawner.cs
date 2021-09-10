using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Header("Normal Asteroids")]
    public Transform baseRockStorage;
    public GameObject baseRockPrefab;
    public float baseRockSpawnCooldown;
    public float baseRockCDVariation;
    public int baseRockMaxNumberPerWave;

    [Header("Big Asteroids")]
    public Transform bigRockStorage;
    public GameObject bigRockPrefab;
    public float bigRockSpawnCooldown;
    public float bigRockCDVariation;

    [Header("Debris")]
    public GameObject debrisPrefab;
    public float debrisSpawnCooldown;

    [Header("Asteroid meshes")]
    public Mesh[] meshes;

    [Header("Asteroid materials")]
    public Material[] materials;

    private float baseRockSpawnTimer = 0f;
    private float bigRockSpawnTimer;
    private float debrisSpawnTimer;

    private void Awake()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject rock = Instantiate(baseRockPrefab, baseRockStorage);
            Mesh newMesh = meshes[Random.Range(0, meshes.Length)];
            rock.GetComponent<MeshFilter>().mesh = newMesh;
            rock.GetComponent<MeshCollider>().sharedMesh = newMesh;
            rock.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];
            rock.GetComponent<ObstacleMovement>().id = i;
        }
        for (int i = 0; i < 10; i++)
        {
            GameObject bigRock = Instantiate(bigRockPrefab, bigRockStorage);
            Mesh newMesh = meshes[Random.Range(0, meshes.Length)];
            bigRock.GetComponent<MeshFilter>().mesh = newMesh;
            bigRock.GetComponent<MeshCollider>().sharedMesh = newMesh;
            bigRock.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];
            bigRock.GetComponent<ObstacleMovement>().id = 50 + i;
        }

        bigRockSpawnTimer = bigRockSpawnCooldown;
        debrisSpawnTimer = debrisSpawnCooldown;
    }

    void Update()
    {
        BaseRockSpawnUpdate();
        BigRockSpawnUpdate();
        DebrisSpawnUpdate();
    }

    private void BaseRockSpawnUpdate()
    {
        if (baseRockSpawnTimer <= 0f)
        {
            SimpleRockActivation();
            baseRockSpawnTimer = baseRockSpawnCooldown + Random.Range(-1, 1) * baseRockCDVariation;
        }
        else
        {
            baseRockSpawnTimer -= Time.deltaTime;
        }
    }

    private void BigRockSpawnUpdate()
    {
        if (bigRockSpawnTimer <= 0f)
        {
            BigRockActivation();
            bigRockSpawnTimer = bigRockSpawnCooldown + Random.Range(-1, 1) * bigRockCDVariation;
        }
        else
        {
            bigRockSpawnTimer -= Time.deltaTime;
        }
    }

    private void DebrisSpawnUpdate()
    {
        if (debrisSpawnTimer <= 0f)
        {
            DebrisActivation();
            debrisSpawnTimer = debrisSpawnCooldown;
        }
        else
        {
            debrisSpawnTimer -= Time.deltaTime;
        }
    }

    private void SimpleRockActivation()
    {
        for (int i = Random.Range(1, baseRockMaxNumberPerWave); i > 0; i--)
        {
            Vector3 spawnPosition = transform.position;
            spawnPosition.x = Random.Range(-(GameData.i.horizontalGameSize - 1), GameData.i.horizontalGameSize - 1);
            spawnPosition.y = Random.Range(GameData.i.verticalGameSize.x + 1, GameData.i.verticalGameSize.y - 1);

            Transform rock = baseRockStorage.GetChild(0);
            rock.SetAsLastSibling();

            rock.GetComponent<ObstacleMovement>().enabled = true;
            rock.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            rock.transform.position = spawnPosition;
        }
    }

    private void BigRockActivation()
    {
        Vector3 spawnPosition = transform.position;
        spawnPosition.x += Random.Range(-(GameData.i.horizontalGameSize - 1), GameData.i.horizontalGameSize - 1);
        spawnPosition.y = Random.Range(-(GameData.i.verticalGameSize.x - 1), GameData.i.verticalGameSize.y - 1);

        Transform rock = bigRockStorage.GetChild(0);
        rock.SetAsLastSibling();
        rock.GetComponent<ObstacleMovement>().enabled = true;
        rock.transform.position = spawnPosition;
        rock.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
    }

    private void DebrisActivation()
    {
        GameObject debris = Instantiate(debrisPrefab, baseRockStorage);
        debris.GetComponent<ObstacleMovement>().enabled = true;
        debris.transform.position = new Vector3(0, transform.position.y, 0);
    }
}