using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Player player;
    // The item on the floor
    public GameObject item;
    // The name of the item on the ground to be recorded in the backpack.
    public string nameItem;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.K))
        {
            this.player.CollectItem(this.nameItem);
            Debug.Log("You have collected a \"" + this.nameItem + "\"");
            Destroy(this.item);
        }
    }
}
