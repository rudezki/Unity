using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public GameObject titleScreen;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timeText;
    public Button restartButton;
    public bool isGameActive;

    private int score;
    private float spawnRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateTime(float timeLeft)
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        timeText.gameObject.SetActive(false);
        isGameActive = false;
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficultySetting)
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        spawnRate /= difficultySetting;
        score = 0;
        UpdateScore(0);
        UpdateTime(60.0f);
        timeText.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
    }
 
}
