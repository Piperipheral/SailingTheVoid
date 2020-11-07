using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlightMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rigidBody;
    private float posX = 0;
    private float posY = 0;
    private float posZ = 0;
    private Vector3 initPosition;
    public Vector3 initOffset;
    public Vector3 speedOffset;
    public float frequency;
    public float amplitude;
    public float rotationFactor;
    private float i;


    public bool enableX;
    public bool enableY;
    public bool enableZ;

    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        i += frequency * Time.deltaTime;
        posX = enableX ? Mathf.Sin(i * speedOffset.x + initOffset.x) : 0;
        posY = enableY ? Mathf.Sin(i * speedOffset.y + initOffset.y) : 0;
        posZ = enableZ ? Mathf.Sin(i * speedOffset.z + initOffset.z) : 0;
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Cos(i) * Time.deltaTime * rotationFactor));
        rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
        //rigidBody.position = new Vector3(posX + initPosition.x, posY + initPosition.y, posZ + initPosition.z) * amplitude;
    }
}
