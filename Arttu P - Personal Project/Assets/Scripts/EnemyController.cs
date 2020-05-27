using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed;
    private float xSpeedModifier;
    private float coughWaitTimer;
    private float zBoundary = -10.0f;
    private bool gameOverSpeed;
    private PlayerController playerControlScript;
    public GameObject virusCloudPrefab;
    // Start is called before the first frame update
    void Start()
    {
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerController>();
        speed = Random.Range(4.0f, 6.0f);

        gameOverSpeed = false;
        coughWaitTimer = Random.Range(1.0f, 3.0f);
        xSpeedModifier = Random.Range(-0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(new Vector3(xSpeedModifier,0,-1) * -speed * Time.deltaTime);

        if (transform.position.z < zBoundary)
        {
            Destroy(gameObject);
        }
        
        coughWaitTimer -= Time.deltaTime;

        if (coughWaitTimer <= 0.0f && tag == "Infected")
        {
            Vector3 pointOfOrigin = new Vector3(transform.position.x, 1, transform.position.z);
            Instantiate(virusCloudPrefab, pointOfOrigin, virusCloudPrefab.gameObject.transform.rotation);
            coughWaitTimer = Random.Range(1.0f, 3.0f);
            xSpeedModifier = Random.Range(-0.5f, 0.5f);

        } else if (coughWaitTimer <= 0.0f && tag == "Person")
        {
            xSpeedModifier = Random.Range(-0.5f, 0.5f);
        }
        if (playerControlScript.gameOver && !gameOverSpeed)
        {
            SetGameOverSpeed();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "VirusCloud" && gameObject.tag == "Person")
        {
            gameObject.tag = "Infected";
        }
    }
    private void SetGameOverSpeed()
    {
        speed /= 2;
        gameOverSpeed = true;
    }
}
