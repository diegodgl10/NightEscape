using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    // The player object
    private Player player;
    // The requirement to open the door
    public string requirement = "isClosed";
    // The generator power
    public Generator generator;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.K))
        {
            if (this.generator == null)
            {
                return;
            }
            if (this.generator.GetStatusGenerator() == false)
            {
                Debug.Log("The elevator has no power to operate");
                return;

            }
            if (this.requirement == "isClosed")
            {
                Debug.Log("The elevator is not in operation");
            }
            else
            {
                if (this.requirement == "null" || this.player.HasItem(this.requirement))
                {
                    SceneManager.LoadScene("EndGame");
                }
                else
                {
                    Debug.Log("Elevator locked, you need a key");
                }
            }
        }
    }
}
