using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;
    public GameObject virusCloud;
    
    public float spawnRangeX = 12.0f;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomEnemy()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        int randomIndex = Random.Range(0, enemies.Length);
        GameObject randomEnemy = enemies[randomIndex];

        Vector3 spawnPos = new Vector3(randomX, spawnRangeY, spawnRangeZ);

        Instantiate(randomEnemy, spawnPos, randomEnemy.gameObject.transform.rotation);

        if (randomEnemy = GameObject.FindGameObjectWithTag("Infected"))
        {
            StartCoroutine(SpawnCloudOnEnemy(randomEnemy));
        }
    }
    void SpawnPowerup()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);

        Vector3 spawnPos = new Vector3(randomX, spawnRangeY, spawnRangeZ);

        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }
    IEnumerator SpawnCloudOnEnemy(GameObject infectedEnemy)
    {
        

        Vector3 pointOfOrigin = new Vector3(infectedEnemy.transform.position.x, infectedEnemy.transform.position.y, infectedEnemy.transform.position.z);
        GameObject childCloud = Instantiate(virusCloud, pointOfOrigin, Quaternion.identity);
        childCloud.transform.parent = gameObject.transform;
        
        Instantiate(childCloud, pointOfOrigin, virusCloud.gameObject.transform.rotation);
        yield return new WaitForSeconds(3);
    }
}
