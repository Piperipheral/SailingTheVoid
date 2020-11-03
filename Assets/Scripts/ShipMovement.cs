using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody rigidBody;
    public ParticleSystem buttFire;
    public bool isEngineOn;
    public float speedForward;
    public float speedRotation;
    private float curRot;
    private bool isRotating;
    private float curSpeed;
    // Start is called before the first frame update
    void Start()
    {
        isRotating = false;
        rigidBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {

        //moving forward
        if (Input.GetKeyDown(KeyCode.W)) isEngineOn = true;
        else if (Input.GetKeyUp(KeyCode.W)) isEngineOn = false;
        if (Input.GetKey(KeyCode.D))
        {
            isRotating = true;
            if (curRot < speedRotation) curRot += 0.1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            isRotating = true;
            if (curRot > -speedRotation) curRot -= 0.1f;
        }
        if (isRotating)
        {
            if (Mathf.Abs(curRot) > 0.1) curRot *= 0.97f;
            else curRot = 0;
        }
        if (isEngineOn)
        {
            if (curSpeed < speedForward) curSpeed++;
            else curSpeed = speedForward;
            buttFire.enableEmission = true;
        }
        else
        {
            if (curSpeed > 0.1f) curSpeed *= 0.99f;
            else curSpeed = 0;
            buttFire.enableEmission = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, curRot, 0));
        rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
        rigidBody.velocity = transform.rotation * new Vector3(0, 0, curSpeed * Time.deltaTime);
        //turning
    }
}
