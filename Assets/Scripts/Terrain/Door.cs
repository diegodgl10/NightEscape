    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject destinationDoor;
    private Player player;
    public string requirement = "isClosed";
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.K))
        {
            if (this.requirement == "isClosed")
            {
                Debug.Log("Door Locked, cannot be opened");
            }
            else
            {
                if (this.requirement == "null" || this.player.HasItem(this.requirement))
                {
                    this.player.transform.position = destinationDoor.transform.position;
                }
                else
                {
                    Debug.Log("Locked door, you need a key");
                }
            }
        }
    }
}
