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
    private int health = 5;
    // Player's health bar UI
    private HealthBar healthBar;

    // Indicator of whether we are stunned
    private bool stunned = false;
    // Time we have been stunned
    private float elapsedStunCounter = 0f;
    // Time we must be alert when receiving damage
    private float stunTime = 1.25f;

    // Our backpack
    private Backpack backpack;

    private GameOver gameOver;

    public AudioClip audioClipDamage;
    public AudioSource audioSourceDamage;

    // cooldown

    // Start is called before the first frame update
    void Start()
    {
        this.rb2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        this.backpack = GameObject.Find("Backpack").GetComponent<Backpack>();
        this.gameOver = GameObject.Find("GameOver").GetComponent<GameOver>();
        this.audioSourceDamage = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (this.stunned == true)
        {
            StunWaitingTime();
        }
        else
        {
            Movement();
        }
    }

    /**
     * Method for inflicting damage to the player
     */
    public void DamageToPlayer()
    {
        if (this.stunned)
        {
            return;
        }
        this.health--;
        if (this.health < 0) {
            // Debug.Log("Game Over");
            this.gameOver.EndOfGame();
        }
        else
        {
            this.stunned = true;
            this.animator.SetBool("Stunned", this.stunned);
            this.elapsedStunCounter = 0f;
            this.healthBar.UpdateHealth(this.health);
            this.audioSourceDamage.PlayOneShot(this.audioClipDamage);
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

    /**
     * Indicates the quantity of objects of the same type in the backpack
     */
    public bool HasItem(string item)
    {
        if (this.backpack.ItemQuantity(item) <= 0)
        {
            return false;
        }
        return true;
    }

    /**
     * Collect an item
     */
    public void CollectItem(string item)
    {
        this.backpack.AddItem(item);
    }

    /**
     * Remove an item
     */
    public void RemoveItem(string item)
    {
        this.backpack.SubtractItem(item);
    }

    // Controls the damage dealt by an enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.tag == "Enemy")
        {
            DamageToPlayer();
        }
        */
    }

    // Indicates if the stun timeout has passed
    private void StunWaitingTime()
    {
        this.elapsedStunCounter += Time.fixedDeltaTime;
        if (this.elapsedStunCounter >= this.stunTime)
        {
            this.elapsedStunCounter = 0f;
            this.stunned = false;
            this.animator.SetBool("Stunned", this.stunned);
        }
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
