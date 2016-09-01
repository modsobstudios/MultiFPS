using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuHandler : MonoBehaviour
{

    public Canvas canvas;
    bool buf;

    // Use this for initialization
    void Start()
    {
        buf = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !buf)
        {
            canvas.enabled = !canvas.isActiveAndEnabled;
            buf = true;
        }
        if(!Input.GetKey(KeyCode.Escape))
        {
            buf = false;
        }
    }

    public void sceneChange(int _i)
    {
        SceneManager.LoadScene(_i);
    }

    public void closeMenu()
    {
        canvas.enabled = !canvas.isActiveAndEnabled;
    }
}
