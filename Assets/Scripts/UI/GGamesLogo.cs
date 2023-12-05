using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GGamesLogo : MonoBehaviour
{
    // G Ganes logo
    public GameObject gGames;
    // Controls image
    public GameObject controls;

    private bool changeMade = false;

    // Variable to count time
    private float tiempoTranscurrido = 0f;
    // Variable timeout before screen switching
    private float intervalo = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.gGames.SetActive(true);
        this.controls.SetActive(false);
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
        if (this.tiempoTranscurrido >= 2.5f && this.changeMade == false)
        {
            this.gGames.SetActive(false);
            this.controls.SetActive(true);
            this.changeMade = true;
        }
        if (this.tiempoTranscurrido >= this.intervalo)
        {
            this.tiempoTranscurrido = 0f;
            return true;
        }
        return false;
    }
}
