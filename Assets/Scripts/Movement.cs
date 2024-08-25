using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float tiltingSpeed = 100f;
    [SerializeField] float thrustPower = 1000f;
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    
    private void ProcessThrust() {

        if (Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(Vector3.up*thrustPower* Time.deltaTime);
        }

    }

    private void ProcessRotation() {
        int tiltingCoefficient = 0;

        if (Input.GetKey(KeyCode.A)) {
            tiltingCoefficient++;
        }
        if (Input.GetKey(KeyCode.D)) {
            tiltingCoefficient--;
        }
        float tiltValue = tiltingCoefficient*tiltingSpeed*Time.deltaTime;

        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward*tiltValue);
        rb.freezeRotation = false;
    }
}
