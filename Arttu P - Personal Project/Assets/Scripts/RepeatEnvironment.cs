using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatEnvironment : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatHeight;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatHeight = (GetComponent<BoxCollider>().size.z / 2) * 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < startPos.z - repeatHeight)
        {
            transform.position = startPos;
        }
    }
}
