using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Animation for the health bar
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.animator.SetInteger("PlayerHealth", 5);
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
        this.animator.SetInteger("PlayerHealth", healthPlayer);
        Debug.Log(healthPlayer);
    }
}
