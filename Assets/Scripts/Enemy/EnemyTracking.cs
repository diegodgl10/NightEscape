using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracking : MonoBehaviour
{
    // Rigid body in 2D
    private Rigidbody2D rb2D;
    // Animation for the character
    private Animator animator;
    // Spawn of the enemy
    public GameObject spawn;

    // Movement speed
    private float speedMovement = 2.25f; //16f
    private float minDistance = 0.8f;
    private float rangeDistance = 7.0f;

    // Indicator of whether the enemy is stunned
    private bool cooldown = false;
    // Time we have been cooldown
    private float elapsedCooldownCounter = 0f;
    // Time we must be alert when receiving damage
    private float cooldownTime = 2.25f;
    private float attackAnimationCounter = 0f;
    private float attackAnimationTime = 0.3f;

    private Player player;

    // Indicator of whether we are stunned
    private bool stunned = false;
    // Time we have been stunned
    private float elapsedStunCounter = 0f;
    // Time we must be alert when receiving damage
    private float stunTime = 1.25f;

    public AudioClip audioClipDamage;
    public AudioSource audioSourceDamage;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindWithTag("Player").GetComponent<Player>();
        this.rb2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.animator.SetFloat("LastHorizontal", 0);
        this.animator.SetFloat("LastVertical", -1);
        this.audioSourceDamage = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        AttackAnimation();
        if (Vector2.Distance(this.transform.position, this.player.transform.position) > this.rangeDistance)
        {
            if (Vector2.Distance(this.transform.position, this.spawn.transform.position) != 0)
            {
                this.transform.position = this.spawn.transform.position;
            }
            else
            {
                return;
            }
        }
        if (this.stunned == true)
        {
            StunWaitingTime();
            if (this.cooldown == true)
            {
                CooldownWaitingTime();
            }
            return;
        }
        if (Vector2.Distance(this.transform.position, this.player.transform.position) > this.minDistance)
        {
            Movement();
        }
        else
        {
            if (this.cooldown == true)
            {
                CooldownWaitingTime();
            }
            else
            {
                Attack();
            }
        }
    }

    private void Movement()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, this.player.transform.position, this.speedMovement * Time.fixedDeltaTime);
        Flip();
    }

    private void Attack()
    {
        // Debug.Log("The enemy has attacked you");
        if (this.cooldown == false)
        {
            this.animator.SetBool("Attacking", true);
            this.player.DamageToPlayer();
            this.cooldown = true;
        }
    }

    private void AttackAnimation()
    {
        this.attackAnimationCounter += Time.fixedDeltaTime;
        if (this.attackAnimationCounter >= this.attackAnimationTime)
        {
            this.attackAnimationCounter = 0f;
            this.animator.SetBool("Attacking", false);
        }
    }

    /**
     * Method for inflicting damage to the enemy
     */
    public void DamageToEnemy()
    {
        if (this.stunned)
        {
            return;
        }
        this.stunned = true;
        this.animator.SetBool("Stunned", this.stunned);
        this.elapsedStunCounter = 0f;
        this.audioSourceDamage.PlayOneShot(this.audioClipDamage);
    }

    // Indicates if the stun timeout has passed
    private void CooldownWaitingTime()
    {
        this.elapsedCooldownCounter += Time.fixedDeltaTime;
        if (this.elapsedCooldownCounter >= this.cooldownTime)
        {
            this.elapsedCooldownCounter = 0f;
            this.cooldown = false;
        }
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

    private void Flip()
    {
        int orientation = SelectOrientation();
        switch (orientation)
        {
            case 0:
                this.animator.SetFloat("MovHorizontal", 0);
                this.animator.SetFloat("MovVertical", 1);
                break;
            case 3:
                this.animator.SetFloat("MovHorizontal", 1);
                this.animator.SetFloat("MovVertical", 0);
                break;
            case 6:
                this.animator.SetFloat("MovHorizontal", 0);
                this.animator.SetFloat("MovVertical", -1);
                break;
            case 9:
                this.animator.SetFloat("MovHorizontal", -1);
                this.animator.SetFloat("MovVertical", 0);
                break;
            default:
                Debug.LogError("Orientation not found");
                break;
        }
    }

    // Returns 0 if the character is at the top,
    // 3 if at the right,
    // 6 if at the bottom
    // and 9 if at the left.
    private int SelectOrientation()
    {
        float myPositionX = this.transform.position.x;
        float myPositionY = this.transform.position.y;
        float playerPositionX = this.player.transform.position.x;
        float playerPositionY = this.player.transform.position.y;

        float difX = (myPositionX > playerPositionX) ? myPositionX - playerPositionX : playerPositionX - myPositionX;
        float difY = (myPositionY > playerPositionY) ? myPositionY - playerPositionY : playerPositionY - myPositionY;

        if (difX > difY)
        {
            return (myPositionX < playerPositionX) ? 3 : 9;
        }
        else
        {
            return (myPositionY < playerPositionY) ? 0 : 6;
        }
    }
}
