using UnityEngine;
using System.Collections;

public class playerStealth : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnTriggerStay(Collider _col)
    {
        if (_col.tag == "Finish")
        {
            float distance = (Vector3.Distance(transform.position, _col.transform.position) / GetComponent<SphereCollider>().radius);
            Renderer[] rends = gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in rends)
            {
                Color color;
                foreach (Material mat in rend.materials)
                {
                    color = mat.color;
                    color.a = Mathf.Lerp(1f, 0f, distance);
                    mat.color = color;
                }
            }
        }
    }
}
