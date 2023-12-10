using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Notification : MonoBehaviour
{
    public TMP_Text tmpNotification;
    public GameObject notificationRectangle;
    public GameObject notificationText;
    public AudioClip audioClipNotification;
    public AudioSource audioSourceNotification;

    private void Start()
    {
        this.tmpNotification.text = "";
        this.notificationRectangle.SetActive(false);
        this.notificationText.SetActive(false);
        this.audioSourceNotification = this.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            this.notificationRectangle.SetActive(false);
            this.notificationText.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Notify(string notification)
    {
        this.notificationRectangle.SetActive(true);
        this.notificationText.SetActive(true);
        this.tmpNotification.text = notification;
        this.audioSourceNotification.PlayOneShot(this.audioClipNotification);
        Time.timeScale = 0f;
    }
}
