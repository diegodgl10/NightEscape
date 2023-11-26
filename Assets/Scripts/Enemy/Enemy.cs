using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Movement speed
    private float speedMovement = 2.25f; //16f
    // Direction in 2D
    private Vector2 direction = Vector2.zero;
    // Rigid body in 2D
    private Rigidbody2D rb2D;
    // Horizontal movement value
    private float movHorizontal;
    // Vertical movement value
    private float movVertical;
    // Animation for the character
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.rb2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Movement();
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

        this.direction = new Vector2(this.movHorizontal, this.movVertical).normalized;

        this.rb2D.MovePosition(this.rb2D.position + this.direction * this.speedMovement * Time.fixedDeltaTime);

        this.movHorizontal = this.movVertical = 0;
    }
}
