using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public AudioClip audioClipAlert;
    public AudioSource audioSourceAlert;

    // Animation for the health bar
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.animator.SetInteger("PlayerHealth", 5);
        this.audioSourceAlert = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     
    // }

    /**
     * Updates the player's health bar
     */
    public void UpdateHealth(int healthPlayer)
    {
        if (healthPlayer == 1)
        {
            this.audioSourceAlert.PlayOneShot(this.audioClipAlert);
        }
        this.animator.SetInteger("PlayerHealth", healthPlayer);
    }
}
