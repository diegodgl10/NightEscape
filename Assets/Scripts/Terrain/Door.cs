    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // The door of destiny
    public GameObject destinationDoor;
    // The player object
    private Player player;
    // The requirement to open the door
    public string requirement = "isClosed";
    // Player notification
    public Notification notifications;

    public AudioClip audioClipDoor;
    public AudioSource audioSourceDoor;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindWithTag("Player").GetComponent<Player>();
        this.audioSourceDoor = this.GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.K))
        {
            if (this.requirement == "isClosed")
            {
                // Debug.Log("Door Locked, cannot be opened");
                this.notifications.Notify("Door Locked, cannot be opened");
            }
            else
            {
                if (this.requirement == "null" || this.player.HasItem(this.requirement))
                {
                    this.audioSourceDoor.PlayOneShot(this.audioClipDoor);
                    this.player.transform.position = destinationDoor.transform.position;
                }
                else
                {
                    // Debug.Log("Locked door, you need a key");
                    this.notifications.Notify("Locked door, you need a key");
                }
            }
        }
    }
}
