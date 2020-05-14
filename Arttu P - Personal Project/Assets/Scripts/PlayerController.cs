using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float horizontalSpeed;
    public float verticalSpeed;
    public bool gameOver = false;
    public float zBoundary = 10.0f;
    public float xBoundary = 10.0f;
    private GameObject virus;
    // Start is called before the first frame update
    void Start()
    {
        virus = GameObject.Find("Virus Cloud");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        PlayerBoundary();
  
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
        if (transform.position.z > zBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundary);
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
        if (other.gameObject.tag == "Virus cloud")
        {
            Debug.Log("Game over");
            gameOver = true;
        }
        if (other.gameObject.tag == "Powerup")
        {
            Debug.Log("Power up!");
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Person")
        {

        }
    }
}
