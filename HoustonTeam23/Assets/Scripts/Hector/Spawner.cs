using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform baseRockStorage;
    public Transform bigRockStorage;

    public float baseRockSpawnCooldown;
    public float baseRockCDVariation;
    public int baseRockMaxNumberPerWave;

    public float bigRockSpawnCooldown;
    public float bigRockCDVariation;

    private float baseRockSpawnTimer = 0f;
    private float bigRockSpawnTimer = 0f;

    void Update()
    {
        BaseRockSpawnUpdate();
        BigRockSpawnUpdate();
    }

    private void BaseRockSpawnUpdate()
    {
        if (baseRockSpawnTimer <= 0f)
        {
            SimpleRockActivation();
            baseRockSpawnTimer = baseRockSpawnCooldown + Random.Range(-baseRockCDVariation, baseRockCDVariation);
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
            bigRockSpawnTimer = bigRockSpawnCooldown + Random.Range(-bigRockCDVariation, bigRockCDVariation);
        }
        else
        {
            bigRockSpawnTimer += Time.deltaTime;
        }
    }

    public void SimpleRockActivation()
    {
        for (int i = Random.Range(1, baseRockMaxNumberPerWave); i > 0; i--)
        {
            Vector3 spawnPosition = transform.position;
            spawnPosition.x = Random.Range(-(GameData.i.horizontalGameSize - 1), GameData.i.horizontalGameSize - 1);
            spawnPosition.y = Random.Range(GameData.i.verticalGameSize.x + 1, GameData.i.verticalGameSize.y - 1);

            Transform rock = baseRockStorage.GetChild(0);
            rock.SetAsLastSibling();

            rock.GetComponent<ObstacleMovement>().enabled = true;
            rock.transform.position = spawnPosition;
        }
    }

    public void BigRockActivation()
    {
        Vector3 spawnPosition = transform.position;
        spawnPosition.x += Random.Range(-(GameData.i.horizontalGameSize - 1), GameData.i.horizontalGameSize - 1);
        spawnPosition.y = Random.Range(-(GameData.i.verticalGameSize.x - 1), GameData.i.verticalGameSize.y - 1);

        Transform rock = bigRockStorage.GetChild(0);
        rock.SetAsLastSibling();
        rock.gameObject.GetComponent<ObstacleMovement>().enabled = true;
        rock.transform.position = spawnPosition;
    }
}