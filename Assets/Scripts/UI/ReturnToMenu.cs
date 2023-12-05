using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{

    public string returnWith = "K";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (returnWith == "K" && Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("Menu");
        }
        if (returnWith == "L" && Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
