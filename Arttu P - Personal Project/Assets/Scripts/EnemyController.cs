using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;

    private float zBoundary = -10.0f;
    private Rigidbody objectRb;
    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);

        if (transform.position.z < zBoundary)
        {
            Destroy(gameObject);
        }

    }
}
