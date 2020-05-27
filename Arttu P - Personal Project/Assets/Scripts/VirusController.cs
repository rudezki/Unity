using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{
    private static float speed = 2.0f;
    private static float windDirection; 
    private float zBoundary = -10.0f;
    private Rigidbody objectRb;

    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
        windDirection = Random.Range(-1.0f, 1.0f);
        speed = Random.Range(1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(windDirection, 0, 1.5f) * -speed * Time.deltaTime);

        if (transform.position.z < zBoundary)
        {
            Destroy(gameObject);
        }
    }

}
