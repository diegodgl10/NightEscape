using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // Animation for the generator
    private Animator animator;
    // The state of the fuse box
    private bool statusEnabled = false;
    // The player object
    private Player player;
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
            if (this.statusEnabled == false)
            {
                this.statusEnabled = true;
                this.animator.SetBool("StatusEnabled", this.statusEnabled);
                Debug.Log("Generator on");
            }
        }
    }

    /**
     * Return the status of the generator
     */
    public bool GetStatusGenerator()
    {
        return this.statusEnabled;
    }
}
