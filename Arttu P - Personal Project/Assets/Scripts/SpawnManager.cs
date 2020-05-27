using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;
    public GameObject virusCloud;
    public GameObject rightWall;
    public GameObject leftWall;
    public Button startGameButton;
    public PlayerController playerControls;
    
    private float spawnRangeX = 11.0f;
    private float spawnRangeZ = 16.0f;
    private float spawnRangeY = 0.5f;
    [SerializeField] private float buildingSpawnRangeZ = 50.0f;
    [SerializeField] private float rightWallSpawnRangeX = 34.3f;
    [SerializeField] private float leftWallSpawnRangeX = -17.0f;
    
    private float powerupSpawnTime = 6.0f;
    [SerializeField] private float enemySpawnTime = 2.5f;
    [SerializeField] private float buildingSpawnTimer = 50.0f;
    [SerializeField] private float buildingStartDelayTimer = 3.0f;
    private float startDelay = 1.0f;
    //private float coughStartDelay = 1.5f;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void BeginSpawning()
    {
        if (!playerControls.youWinTheGame)
        {
            StartCoroutine(SpawnRandomEnemy());
            InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
            InvokeRepeating("SpawnBuildings", buildingStartDelayTimer, buildingSpawnTimer);
            StartCoroutine(DifficultyIncrease());
        }
    }
    IEnumerator SpawnRandomEnemy()
    {
        while (!playerControls.youWinTheGame)
        {
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
            int randomIndex = Random.Range(0, enemies.Length);
            GameObject randomEnemy = enemies[randomIndex];

            Vector3 spawnPos = new Vector3(randomX, spawnRangeY, spawnRangeZ);

            yield return new WaitForSeconds(enemySpawnTime);
            Instantiate(randomEnemy, spawnPos, randomEnemy.gameObject.transform.rotation);
        }
    }
    void SpawnPowerup()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);

        Vector3 spawnPos = new Vector3(randomX, spawnRangeY, spawnRangeZ);

        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }
    void SpawnBuildings()
    {

        Vector3 spawnPos = new Vector3(rightWallSpawnRangeX, spawnRangeY, buildingSpawnRangeZ);
        Vector3 spawnPos2 = new Vector3(leftWallSpawnRangeX , spawnRangeY, buildingSpawnRangeZ);

        Instantiate(rightWall, spawnPos, rightWall.gameObject.transform.rotation);
        Instantiate(leftWall, spawnPos2, leftWall.gameObject.transform.rotation);
    }
    IEnumerator DifficultyIncrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            if (enemySpawnTime > 0.5f)
            {
                enemySpawnTime -= 0.1f;
            }
        }
    }
}
