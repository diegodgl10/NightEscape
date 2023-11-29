    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject destinationDoor;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindWithTag("Player");   
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.L))
        {
            this.player.transform.position = destinationDoor.transform.position;
        }
    }
}
