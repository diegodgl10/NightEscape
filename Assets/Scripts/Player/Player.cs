using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Rigid body in 2D
    private Rigidbody2D rb2D;
    // Animation for the character
    private Animator animator;

    // Movement speed
    private float speedMovement = 2f; //16f
    // Horizontal movement value
    private float movHorizontal;
    // Vertical movement value
    private float movVertical;

    // Player health
    public int health = 5;
    // Player's health bar UI
    private HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        this.rb2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Movement();
    }

    /**
     * Method for inflicting damage to the player
     */
    public void DamageToPlayer()
    {
        this.health--;
        if (this.health < 0) {
            Debug.Log("Game Over");
        }
        else
        {
            this.healthBar.UpdateHealth(this.health);
        }
    }

    /**
     * Method for healing the player
     */
    public void HealToPlayer()
    {
        this.health = (this.health+2 > 5) ? 5 : this.health+2;
        this.healthBar.UpdateHealth(this.health);
    }

    // Method of controlling movement
    private void Movement()
    {
        
            if (Input.GetAxis("Horizontal") != 0)
            {
                this.movHorizontal = (Input.GetAxis("Horizontal") < 0) ? -1 : 1;
            }
            if (Input.GetAxis("Vertical") != 0)
            {
                this.movVertical = (Input.GetAxis("Vertical") < 0) ? -1 : 1;
            }

            this.animator.SetFloat("MovHorizontal", this.movHorizontal);
            this.animator.SetFloat("MovVertical", this.movVertical);
            
            if (this.movHorizontal != 0 || this.movVertical != 0)
            {
                this.animator.SetFloat("LastHorizontal", this.movHorizontal);
                this.animator.SetFloat("LastVertical", this.movVertical);
            }

            Vector2 direction = new Vector2(this.movHorizontal, this.movVertical).normalized;

            this.rb2D.MovePosition(this.rb2D.position + direction * this.speedMovement * Time.fixedDeltaTime);

            this.movHorizontal = this.movVertical = 0;
    }
}
