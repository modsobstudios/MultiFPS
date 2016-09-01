using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour
{

    public float playerSpeed = 10.0f;
    public float mouseSpeed = 10.0f;
    public playerMove move;
    float xInput = 0.0f;
    float zInput = 0.0f;
    float yRotato = 0.0f;
    float xRotato = 0.0f;
    Vector3 velX, velZ, velF, rot, camRot;

    // Use this for initialization
    void Start()
    {
        move = GetComponent<playerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        GetTransInput();
        GetYRotInput();
        GetXRotInput();
        move.Thrust(velF);
    }

    void GetTransInput()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        velX = xInput * transform.right;
        velZ = zInput * transform.forward;

        velF = velX + velZ;
        velF = velF.normalized;
        velF *= playerSpeed;
    }

    void GetYRotInput()
    {
        yRotato = Input.GetAxis("Mouse X");

        rot = new Vector3(0.0f, yRotato, 0.0f);
        rot *= mouseSpeed;

        move.Rot(rot);
    }

    void GetXRotInput()
    {
        xRotato = Input.GetAxis("Mouse Y");

        camRot = new Vector3(xRotato, 0.0f, 0.0f);
        camRot *= mouseSpeed;
       
        move.RotCam(camRot);
    }
}
