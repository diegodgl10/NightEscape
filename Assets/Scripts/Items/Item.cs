using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // The backpack of the floor
    private Backpack backpack;
    // The player
    private Player player;
    // The item on the floor
    public GameObject item;
    // The name of the item on the ground to be recorded in the backpack.
    public string nameItem;
    // Player notification
    public Notification notifications;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindWithTag("Player").GetComponent<Player>();
        this.backpack = GameObject.Find("Backpack").GetComponent<Backpack>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.K))
        {
            this.player.CollectItem(this.nameItem);
            Destroy(this.item);
            // Debug.Log("You have collected a \"" + this.nameItem + "\"");
            string descriptionItem = this.backpack.ItemDescription(this.nameItem);
            string message = "";
            message = "You have collected a \"" + this.nameItem + "\"";
            message += "\n" + descriptionItem;
            this.notifications.Notify(message);
        }
    }
}
