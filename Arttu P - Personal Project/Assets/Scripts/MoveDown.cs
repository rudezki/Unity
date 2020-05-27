using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{

    public float speed = 5.0f;

    public PlayerController playerControlScript;
    private float zBoundary = -10.0f;
    private Rigidbody objectRb;

    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControlScript.gameOver && playerControlScript.gameStart)
        {
            transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        }
        if (transform.position.z < zBoundary)
        {
            Destroy(gameObject);
        }
    }
}
