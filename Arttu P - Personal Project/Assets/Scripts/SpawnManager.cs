using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;
    public GameObject virusCloud;

    private float spawnRangeX = 12.0f;
    private float spawnRangeZ = 16.0f;
    private float spawnRangeY = 0.5f;

    private float powerupSpawnTime = 5.0f;
    private float enemySpawnTime = 1.0f;
    private float virusSpawnTime = 1.5f;
    private float startDelay = 1.0f;
    private float coughStartDelay = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
        InvokeRepeating("SpawnCloudOnEnemy", coughStartDelay, virusSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomEnemy()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, spawnRangeY, spawnRangeZ);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
        
    }
    void SpawnPowerup()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);

        Vector3 spawnPos = new Vector3(randomX, spawnRangeY, spawnRangeZ);

        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }
    void SpawnCloudOnEnemy()
    {
        foreach (GameObject infectedEnemy in GameObject.FindGameObjectsWithTag("Infected"))
        {
            Vector3 spawnPos = new Vector3(infectedEnemy.gameObject.transform.rotation.x, virusCloud.gameObject.transform.rotation.y, infectedEnemy.gameObject.transform.rotation.z);

            Instantiate(virusCloud, spawnPos, virusCloud.gameObject.transform.rotation);
        }
    }
}
