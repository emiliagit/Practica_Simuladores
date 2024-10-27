using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTarget : MonoBehaviour
{
    public List<Transform> spawnPoints; 
    public float generationInterval;

    private float nextSpawn;

    void Start()
    {
        nextSpawn = generationInterval;
    }

    void Update()
    {
        nextSpawn -= Time.deltaTime;

        if (nextSpawn <= 0f)
        {
            GenerarObstaculo();
            nextSpawn = generationInterval;
        }
    }

    void GenerarObstaculo()
    {
        int obstacleType = Random.Range(0, ObjectPooling.instance.objectPrefabs.Length);
        GameObject obstacle = ObjectPooling.instance.GetObject(obstacleType);

        int randomIndex = Random.Range(0, spawnPoints.Count);
        Vector3 spawnPosition = spawnPoints[randomIndex].position;

        obstacle.transform.position = spawnPosition;
    }
}
