using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour
{
    Vector3 vel = Vector3.zero;
    Vector3 rot = Vector3.zero;
    Vector3 camrot = Vector3.zero;
    public Camera playerCam;
    Quaternion qot = Quaternion.identity;
    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Thrust(Vector3 velF)
    {
        vel = velF;
    }
    public void Rot(Vector3 _rot)
    {
        rot = _rot;
    }
    public void RotCam(Vector3 _rot)
    {
        camrot = _rot;
    }
    void calcMovement()
    {
        if(vel != Vector3.zero)
        {
            rb.MovePosition(transform.position + vel * Time.fixedDeltaTime);
        }
    }
    void calcRotation()
    {
        qot = Quaternion.Euler(rot);
        rb.MoveRotation(rb.rotation * qot);
        playerCam.transform.Rotate(-camrot);
    }
    void FixedUpdate()
    {
        calcMovement();
        calcRotation();
    }
}
