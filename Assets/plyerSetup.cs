using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class plyerSetup : NetworkBehaviour
{

    public Behaviour[] compDisable;
    Camera sceneCam;

    public string remoteLayer = "RemotePlayer";

    // Use this for initialization
    void Start()
    {
        if(!isLocalPlayer)
        {
            disableComp();
            makeRemote();
        }
        else
        {
            sceneCam = Camera.main;
            if(sceneCam)
            {
                sceneCam.gameObject.SetActive(false);
            }
        }
        assignID();
    }

    void assignID()
    {
        string ID = "Player " + GetComponent<NetworkIdentity>().netId;
        transform.name = ID;

    }
    
    void OnDisable()
    {
        if(sceneCam)
        {
            sceneCam.gameObject.SetActive(true);
        }
    }

    void disableComp()
    {
        for (int i = 0; i < compDisable.Length; i++)
        {
            compDisable[i].enabled = false;
        }
    }

    void makeRemote()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayer);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
