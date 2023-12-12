using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // Rigid body in 2D
    private Rigidbody2D rb2D;
    // Animation for the character
    private Animator animator;

    public GameObject checkpoint1;
    public GameObject checkpoint2;
    public GameObject checkpoint3;
    public GameObject checkpoint4;
    private GameObject nextCheckpoint;
    private int flagNextCheckpoint;

    // Movement speed
    private float speedMovement = 2.25f; //16f
    private float minDistance = 1.1f;

    // Indicator of whether the enemy is stunned
    private bool cooldown = false;
    // Time we have been cooldown
    private float elapsedCooldownCounter = 0f;
    // Time we must be alert when receiving damage
    private float cooldownTime = 2.25f;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindWithTag("Player").GetComponent<Player>();
        this.rb2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.animator.SetFloat("LastHorizontal", 0);
        this.animator.SetFloat("LastVertical", -1);
        this.nextCheckpoint = this.checkpoint1;
        this.flagNextCheckpoint = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
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
        if (Vector2.Distance(this.transform.position, this.nextCheckpoint.transform.position) == 0)
        {
            switch (this.flagNextCheckpoint)
            {
                case 1:
                    this.nextCheckpoint = this.checkpoint2;
                    this.flagNextCheckpoint = 2;
                    break;
                case 2:
                    this.nextCheckpoint = this.checkpoint3;
                    this.flagNextCheckpoint = 3;
                    break;
                case 3:
                    this.nextCheckpoint = this.checkpoint4;
                    this.flagNextCheckpoint = 4;
                    break;
                case 4:
                    this.nextCheckpoint = this.checkpoint1;
                    this.flagNextCheckpoint = 1;
                    break;
                default:
                    this.nextCheckpoint = this.checkpoint1;
                    this.flagNextCheckpoint = 1;
                    break;
            }
            return;
        }
        this.transform.position = Vector2.MoveTowards(this.transform.position, this.nextCheckpoint.transform.position, this.speedMovement * Time.fixedDeltaTime);
        Flip();
    }

    private void Attack()
    {
        // Debug.Log("The enemy has attacked you");
        if (this.cooldown == false)
        {
            this.player.DamageToPlayer();
            this.cooldown = true;
        }
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

    private void Flip()
    {
        int orientation = SelectOrientationCheckpoint();
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
    private int SelectOrientationPlayer()
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


    // Returns 0 if the next checkpoint is at the top,
    // 3 if at the right,
    // 6 if at the bottom
    // and 9 if at the left.
    private int SelectOrientationCheckpoint()
    {
        float myPositionX = this.transform.position.x;
        float myPositionY = this.transform.position.y;
        float checkpointPositionX = this.nextCheckpoint.transform.position.x;
        float checkpointPositionY = this.nextCheckpoint.transform.position.y;

        float difX = (myPositionX > checkpointPositionX) ? myPositionX - checkpointPositionX : checkpointPositionX - myPositionX;
        float difY = (myPositionY > checkpointPositionY) ? myPositionY - checkpointPositionY : checkpointPositionY - myPositionY;

        if (difX > difY)
        {
            return (myPositionX < checkpointPositionX) ? 3 : 9;
        }
        else
        {
            return (myPositionY < checkpointPositionY) ? 0 : 6;
        }
    }
}
