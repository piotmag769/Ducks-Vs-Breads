using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float minimumSpawnTimeSeconds;
    public float maximumSpawnTimeSeconds;
    public int numberOfEntities;
    public GameObject enemyEntity;
    public float spawnAreaRadius;
    private float spawnTimer;

    void Awake()
    {
        SetSpawnTimer();
    }

    void Update()
    {
        if (numberOfEntities > 0) 
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                SpawnEntity();
                SetSpawnTimer();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SetSpawnTimer()
    {
        spawnTimer = Random.Range(minimumSpawnTimeSeconds, maximumSpawnTimeSeconds);
    }

    private void SpawnEntity()
    {
        Vector3 spawnRadius = new Vector3(
            Random.Range(0, spawnAreaRadius), 
            Random.Range(0, spawnAreaRadius),
            0
            );

        Vector3 spawnPositionVector = transform.position + spawnRadius;
        Instantiate(enemyEntity, spawnPositionVector, Quaternion.identity);
        numberOfEntities--;
    }
}
