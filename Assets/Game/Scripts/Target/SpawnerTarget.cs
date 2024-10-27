using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTarget : MonoBehaviour
{
    public Transform spawnPoint;
    public float generationInterval;
    public float heightVariation; 

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

        // Ajustar la altura de spawn de manera aleatoria
        float randomHeight = Random.Range(-heightVariation, heightVariation);
        Vector3 spawnPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y + randomHeight, spawnPoint.position.z);

        obstacle.transform.position = spawnPosition;
    }
}
