using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class plyerSetup : NetworkBehaviour
{

    public Behaviour[] compDisable;
    Camera sceneCam;

    public string remoteLayer = "RemotePlayer";

    public string doNotDraw = "DoNotDraw";
    public GameObject graphic;

    public GameObject playerUI;

    GameObject playerUIIns;

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

            SetLayerRecursively(graphic, LayerMask.NameToLayer(doNotDraw));

            playerUIIns = Instantiate(playerUI);
            playerUIIns.name = playerUI.name;
        }

        GetComponent<Player>().Setup();
    }

    void SetLayerRecursively(GameObject _obj, int _layer)
    {
        _obj.layer = _layer;
        foreach(Transform child in _obj.transform)
        {
            SetLayerRecursively(child.gameObject, _layer);
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player player = GetComponent<Player>();

        gameManager.regPlayer(netID, player);
    }

    void OnDisable()
    {
        Destroy(playerUIIns);

        if(sceneCam)
        {
            sceneCam.gameObject.SetActive(true);
        }

        gameManager.unregPlayer(transform.name);
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
