﻿using UnityEngine;
using UnityEngine.Networking;

public class playerFire : NetworkBehaviour
{

    public Camera cam;
    public playerWeapons weapon;
    public string pTag = "Player";
    public LayerMask mask;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
    [Client]
    void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask))
        {
            if(hit.collider.tag == pTag)
            {
                CmdPlayerHit(hit.collider.name);
                //damage(GameObject.Find(_id));
            }
        }
    }
    [Command]
    void CmdPlayerHit(string _id)
    {
        Debug.Log(_id + " has been hit!");
    }
}
