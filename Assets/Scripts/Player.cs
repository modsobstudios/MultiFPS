using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{

    public int maxHP = 100;
    public float spawnTime = 3.0f;
    public int score;

    [SyncVar]
    public int currHP;

    [SyncVar]
    public bool isDead = false;

    [SerializeField]
    Behaviour[] deathDisable;
    bool[] startUp;

    // Use this for initialization
    public void Setup()
    {
        startUp = new bool[deathDisable.Length];
        for (int i = 0; i < startUp.Length; i++)
        {
            startUp[i] = deathDisable[i].enabled;
        }

        SetDefaults();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;

        if(Input.GetKeyDown(KeyCode.K))
        {
            RpcDamage(1000, transform.name);
        }
    }

    [ClientRpc]
    public void RpcDamage(int _dam, string _sid)
    {
        if (isDead)
            return;
        currHP -= _dam;
        Debug.Log(transform.name + " now has " + currHP + " health.");

        if(currHP <= 0)
        {
            Player _pl = gameManager.getPlayer(_sid);
            _pl.score += 1;
            Debug.Log(_sid + " has killed " + transform.name);
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        for (int i = 0; i < deathDisable.Length; i++)
        {
            deathDisable[i].enabled = false;
        }
        Collider col = GetComponent<Collider>();
        col.enabled = false;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        Debug.Log(transform.name + " is dead.");

        StartCoroutine(Respawn());

    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(gameManager.instance.matchSettings.spawnTime);

        SetDefaults();
        Transform start = NetworkManager.singleton.GetStartPosition();
        transform.position = start.position;
        transform.rotation = start.rotation;

        Debug.Log(transform.name + " respawned.");
    }

    public void SetDefaults()
    {
        isDead = false;
        currHP = maxHP;

        for (int i = 0; i < deathDisable.Length; i++)
        {
            deathDisable[i].enabled = startUp[i];
        }

        Collider col = GetComponent<Collider>();
        col.enabled = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }
}
