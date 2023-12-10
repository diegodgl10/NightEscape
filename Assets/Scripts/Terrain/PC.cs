using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    // The new object
    private string newUSB = "USB with password";
    // The player object
    private Player player;
    // The requirement to open the door
    private string requirement = "USB";
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.K)) 
        {
            if (this.player.HasItem(this.requirement))
            {
                this.player.RemoveItem(this.requirement);
                this.player.CollectItem(this.newUSB);
            }
            else
            {
                Debug.Log("I need a usb to use this computer");
            }
        }
    }
}
