using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class plyerSetup : NetworkBehaviour
{

    public Behaviour[] compDisable;
    Camera sceneCam;

    // Use this for initialization
    void Start()
    {
        if(!isLocalPlayer)
        {
            for(int i = 0; i < compDisable.Length; i++)
            {
                compDisable[i].enabled = false;
            }
        }
        else
        {
            sceneCam = Camera.main;
            if(sceneCam)
            {
                sceneCam.gameObject.SetActive(false);
            }
        }
    }
    
    void OnDisable()
    {
        if(sceneCam)
        {
            sceneCam.gameObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
