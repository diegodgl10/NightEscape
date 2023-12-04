using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GGamesLogo : MonoBehaviour
{

    // Variable to count time
    private float tiempoTranscurrido = 0f;
    // Variable timeout before screen switching
    private float intervalo = 2.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TiempoDeEspera())
        {
            SceneManager.LoadScene("Menu");
        }
    }

    // Indicates if the waiting time has elapsed
    private bool TiempoDeEspera()
    {
        this.tiempoTranscurrido += Time.deltaTime;
        if (this.tiempoTranscurrido >= this.intervalo)
        {
            this.tiempoTranscurrido = 0f;
            return true;
        }
        return false;
    }
}
