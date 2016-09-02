using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour
{
    Vector3 vel = Vector3.zero;
    Vector3 rot = Vector3.zero;
    float camRotX = 0.0f;
    float currCamRotX = 0.0f;
    public Camera playerCam;
    Quaternion qot = Quaternion.identity;
    Rigidbody rb;
    public GameObject plRHand, plLHand, plDag;

    public float camLim = 45.0f;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //plHand = GameObject.FindGameObjectWithTag("pHand");
        //plDag = GameObject.FindGameObjectWithTag("pWep");
    }
    public void Thrust(Vector3 velF)
    {
        vel = velF;
    }
    public void Rot(Vector3 _rot)
    {
        rot = _rot;
    }
    public void RotCam(float _rot)
    {
        camRotX = _rot;
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

        currCamRotX -= camRotX;
        currCamRotX = Mathf.Clamp(currCamRotX, -camLim, camLim);

        playerCam.transform.localEulerAngles = new Vector3(currCamRotX, 0.0f, 0.0f);
        plRHand.transform.position = plDag.transform.position;
        plLHand.transform.position = plDag.transform.position;
    }
    void FixedUpdate()
    {
        calcMovement();
        calcRotation();
    }
}
