using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public AudioClip audioClipGO;
    public AudioSource audioSourceGO;

    public GameObject gameOver;
    public GameObject navigation;
    public GameObject background;

    private bool lostGame = false;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSourceGO = this.GetComponent<AudioSource>();
        this.gameOver.SetActive(false);
        this.navigation.SetActive(false);
        this.background.SetActive(false);
    }

    private void Update()
    {
        if (this.lostGame == true)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void EndOfGame()
    {
        Time.timeScale = 0f;
        this.audioSourceGO.PlayOneShot(this.audioClipGO);
        this.gameOver.SetActive(true);
        this.navigation.SetActive(true);
        this.background.SetActive(true);
        this.lostGame = true;
    }
}
