using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public GameObject target;
    public float xOffset = 0;
    public float yOffset = 0;
    private float yDefault;
    public float zOffset = 0;
    public Vector3 rotation = new Vector3(30, 0, 0);
    private Vector3 defaultRot;
    public float dampTime = 0.3f; //offset from the viewport center to fix damping
    public float mouseEffect = 0.5f;
    private Vector3 velocity = Vector3.zero;
    private float velocityRotateX = 0;
    public bool rotateMouse = false;
    public bool zoom = false;
    public float zoomAmount = 3;
    private float targetFOV;
    public float defaultFOV = 60;
    public float zoomFOV = 110;

    private GameObject defaultTarget;

    private Camera myCam;
    void Start()
    {
        defaultTarget = target;
        myCam = GetComponent<Camera>();
        defaultRot = rotation;
        yDefault = yOffset;
        transform.position = target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (zoom) targetFOV = zoomFOV;
        else targetFOV = defaultFOV;
        if (Mathf.Abs(myCam.fieldOfView - targetFOV) > .1)
        {
            myCam.fieldOfView += (myCam.fieldOfView - targetFOV > 0 ? -1 : 1);
        }
        else
        {
            myCam.fieldOfView = targetFOV;
        }
        //set Taregt Vector
        Vector3 targetVector = target.transform.position;
        targetVector.x = targetVector.x - (xOffset / (zoom ? zoomAmount : 1));
        targetVector.y = targetVector.y - (yOffset / (zoom ? zoomAmount : 1));
        targetVector.z = targetVector.z - (zOffset / (zoom ? zoomAmount : 1));
        // Assign value to Camera position
        if (rotateMouse)
        {
            float mouseX = (Input.mousePosition.x - (Screen.width / 2)) * mouseEffect;
            float mouseY = (Input.mousePosition.y - (Screen.height / 2)) * mouseEffect * -1;

            transform.eulerAngles = new Vector3(
          mouseY + 30,
            mouseX,
           transform.eulerAngles.z);
        }
        if (Mathf.Abs(transform.eulerAngles.x - rotation.x) > .1)
        {
            float newPosition = Mathf.SmoothDamp(transform.eulerAngles.x, rotation.x, ref velocityRotateX, dampTime);
            transform.eulerAngles = new Vector3(newPosition, rotation.y, rotation.z);
        }
        else
        {
            transform.eulerAngles = new Vector3(rotation.x, rotation.y, rotation.z);
        }
        transform.position = Vector3.SmoothDamp(transform.position, targetVector,
                                                ref velocity, dampTime);

    }
    public void setRotationX(int newRotX)
    {
        rotation = new Vector3(newRotX, rotation.y, rotation.z);
        yOffset = yOffset * (rotation.x / defaultRot.x);
    }

    public void setZoom(bool yes)
    {
        zoom = yes;
    }
    public void resetRot()
    {
        yOffset = yDefault;
        rotation = defaultRot;
    }
    public void resetTarget()
    {
        target = defaultTarget;
        zoom = false;
    }
    public void setTarget(GameObject _target)
    {
        target = _target;
    }
}
