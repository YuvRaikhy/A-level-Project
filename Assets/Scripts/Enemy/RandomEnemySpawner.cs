using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    int randomEnemySpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SpawnAEnemy();
    }
    void SpawnAEnemy()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            randomEnemySpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(enemies[i], spawnPoints[randomEnemySpawnPoint].position, Quaternion.identity);
        }
    }
}
