using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [Header("ShipData")]
    public Spaceship ship;
    private Rigidbody rigidBody;
    public ParticleSystem buttFire;
    public float speedForward;
    public float speedRotation;
    private float curRot;
    private bool isRotating;
    public float curSpeed;

    [Header("bob effects")]
    public float amplitude;
    public float frequency;
    private float initY;
    // Start is called before the first frame update
    void Start()
    {
        isRotating = false;
        rigidBody = GetComponent<Rigidbody>();
        initY = rigidBody.position.y;
    }
    private void Update()
    {
        //moving forward
        ship.isEngineOn = Input.GetKey(KeyCode.W);
        if (ship.isEngineOn)
        {
            if (curSpeed <= speedForward) curSpeed += 2;
            else curSpeed = speedForward;
            buttFire.enableEmission = true;
        }
        else
        {
            if (curSpeed > 0.1f) curSpeed *= 0.99f;
            else curSpeed = 0;
            buttFire.enableEmission = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            isRotating = true;
            if (curRot < speedRotation) curRot += 0.2f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            isRotating = true;
            if (curRot > -speedRotation) curRot -= 0.2f;
        }
        if (isRotating)
        {
            if (Mathf.Abs(curRot) > 0.1) curRot *= 0.95f;
            else curRot = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, curRot, 0));
        rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
        rigidBody.velocity = transform.rotation * new Vector3(0, 0, curSpeed * Time.deltaTime);
        rigidBody.position = (new Vector3(rigidBody.position.x, initY + Mathf.Sin(Time.time * frequency) * amplitude, rigidBody.position.z));
        //turning
    }
}
