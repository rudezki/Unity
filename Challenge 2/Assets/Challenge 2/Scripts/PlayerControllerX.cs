using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float dogRate = 1.0f;
    public float nextDog = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextDog)
        {
            nextDog = Time.time + dogRate;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
