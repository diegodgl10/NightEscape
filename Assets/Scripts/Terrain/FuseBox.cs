using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : MonoBehaviour
{
    // Animation for the fuse box
    private Animator animator;
    // The state of the fuse box
    private bool statusEnabled = false;
    // The player object
    private Player player;
    // The requirement to open the door
    private string requirement = "Fuse";
    // Player notification
    public Notification notifications;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.K))
        {
            if (this.player.HasItem(this.requirement) && this.statusEnabled == false)
            {
                this.statusEnabled = true;
                this.animator.SetBool("StatusEnabled", this.statusEnabled);
                // Debug.Log("Fuse box on");
                this.notifications.Notify("Fuse box on");
            }
            else
            {
                // Debug.Log("I need a fuse to use this fuse box");
                this.notifications.Notify("I need a fuse to use this fuse box");
            }
        }
    }
}
