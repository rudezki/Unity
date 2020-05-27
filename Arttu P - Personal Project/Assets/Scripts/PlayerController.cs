using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;

    public GameObject playerModel;
    public GameObject invincibilityIndicator;
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI gameoverText;
    public TextMeshProUGUI gameSplashText;
    public TextMeshProUGUI instructionText;
    public TextMeshProUGUI victoryText;
    public Button gameStartButton;
    public Button restartButton;
    public Rigidbody playerRigidbody;
    public float horizontalInput;
    public float verticalInput;
    public float horizontalSpeed;
    public float verticalSpeed;
    private float zBoundary = 5.0f;
    private float zBoundaryForward = 11.0f;
    private float xBoundary = 12.5f;
    public bool gameOver = false;
    public bool gameStart = false;
    public bool hasImmunity = false;
    public bool youWinTheGame = false;

    private int score;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnim = playerModel.GetComponent<Animator>();
        gameoverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        invincibilityIndicator.transform.position = playerRigidbody.transform.position;
        if (!gameOver && gameStart && !youWinTheGame)
        {
            UpdateScore(1);
            PlayerBoundary();
            MovePlayer();
        }
    }
    //This moves player
    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * horizontalSpeed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * verticalSpeed);
    }
    //This determines the boundaries of the player
    void PlayerBoundary()
    {
        if (transform.position.z < -zBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBoundary);
        }
        if (transform.position.z > zBoundaryForward)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundaryForward);
        }
        if (transform.position.x < -xBoundary)
        {
            transform.position = new Vector3(-xBoundary, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBoundary)
        {
            transform.position = new Vector3(xBoundary, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "VirusCloud" && !hasImmunity && !youWinTheGame)
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 2);
            gameoverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "Powerup")
        {
            hasImmunity = true;
            StartCoroutine(InvulnerabilityFrames());
            invincibilityIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
        
    }
    private void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreDisplay.text = "score: " + score;
    }
    public void StartGame()
    {
        gameStart = true;
        StartCoroutine(CountDownToEnd());
        gameSplashText.gameObject.SetActive(false);
        gameStartButton.gameObject.SetActive(false);
        instructionText.gameObject.SetActive(false);

    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator InvulnerabilityFrames()
    {
        yield return new WaitForSeconds(6);
        hasImmunity = false;
        invincibilityIndicator.SetActive(false);

    }
    IEnumerator CountDownToEnd()
    {
        yield return new WaitForSeconds(60);
        YouWin();
    }
    private void YouWin()
    {
        youWinTheGame = true;
        victoryText.gameObject.SetActive(true);
        playerAnim.SetBool("Static_b", true);
        playerAnim.SetFloat("Speed_f", 0.0f);
        restartButton.gameObject.SetActive(true);
    }
}
