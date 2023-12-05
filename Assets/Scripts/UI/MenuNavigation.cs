using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    // Home screen
    public GameObject homeScreen;
    // Options screen
    public GameObject optionsScreen;
    // Controls screen
    public GameObject controlsScreen;
    // 1 for home screen
    // 2 for options screen
    // 3 for controls screen
    private int screenStatus;

    // Start is called before the first frame update
    void Start()
    {
        this.homeScreen.SetActive(true);
        this.optionsScreen.SetActive(false);
        this.controlsScreen.SetActive(false);
        this.screenStatus = 1;
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.screenStatus)
        {
            case 1:
                HomeScreenNavigation();
                break;
            case 2:
                OptionsScreenNavigation();
                break;
            case 3:
                ControlsScreenNavigation();
                break;
            default:
                Debug.LogError("Unknown navigation status");
                break;
        }
    }

    private void HomeScreenNavigation()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("Floor3");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            this.homeScreen.SetActive(false);
            this.optionsScreen.SetActive(true);
            this.screenStatus = 2;
        }
    }

    private void OptionsScreenNavigation()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            this.homeScreen.SetActive(true);
            this.optionsScreen.SetActive(false);
            this.screenStatus = 1;
        }
    }

    private void ControlsScreenNavigation()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            this.optionsScreen.SetActive(true);
            this.controlsScreen.SetActive(false);
            this.screenStatus = 2;
        }
    }
}
