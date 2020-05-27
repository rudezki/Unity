using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Private variables
    [SerializeField] float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float horsePower = 0;
    private float rpm;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    private float convertToKm = 3.6f;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;

    // Start is called before the first frame update
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //This is where we get the player input.
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Move the vehicle forward
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
        //Turn the vehicle
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        speed = Mathf.Round(playerRb.velocity.magnitude * convertToKm);
        speedometerText.SetText("Speed: " + speed + " km/h");

        rpm = (speed % 30) * 50;
        rpmText.SetText("RPM: " + rpm);
    }
}
