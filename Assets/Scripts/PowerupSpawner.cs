using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] powerUps; /*/ This is a list of all the power-ups to be spawned although in my game there 
                                   * is only one power-up this allows more power-ups to be added in the future /*/     
    int randomSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        int randomChoice = Random.Range(1, 10); // Generates a random number between 1, 10
        if (randomChoice % 2 == 0) // Checks if the number is even
        {
            Debug.Log("Not Spawning this time!"); // If it is even power-up doesn't spawn
        }
        else
        {
            SpawnPowerUp(); // IF it is odd, calls the SpawnPowerUp() function
        }
    }
    void SpawnPowerUp() // Responsible for randomising the spawn point and spawning in the powerup
    {
        for (int i = 0; i < powerUps.Length; i++) // Loops through the entire power-ups list, can be used in future to add more powerups 
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length); // For every power-up, it chooses a random spawn point and spawns it
            Instantiate(powerUps[i], spawnPoints[randomSpawnPoint].position, Quaternion.identity); // Spawns the pwoer-up in that position
        }
    }
}