using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speedMovement = 32f;
    // Variable to count time
    private float timeElapsed = 0f;
    // Variable timeout before moving again
    private float waitingTime = 0.13f;
    private Vector2 direction = Vector2.zero;
    private Rigidbody2D rb2D;
    private float movHorizontal;
    private float movVertical;
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

    private void Movement()
    {
        if (WaitingTime())
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                this.movHorizontal = (Input.GetAxis("Horizontal") < 0) ? -1 : 1;
            }
            if (Input.GetAxis("Vertical") != 0)
            {
                this.movVertical = (Input.GetAxis("Vertical") < 0) ? -1 : 1;
            }

            //this.movHorizontal = Input.GetAxis("Horizontal");
            //this.movVertical = Input.GetAxisRaw("Vertical");

            this.animator.SetFloat("MovHorizontal", this.movHorizontal);
            this.animator.SetFloat("MovVertical", this.movVertical);
            
            if (this.movHorizontal != 0 || this.movVertical != 0)
            {
                this.animator.SetFloat("LastHorizontal", this.movHorizontal);
                this.animator.SetFloat("LastVertical", this.movVertical);
            }

            this.direction = new Vector2(this.movHorizontal, this.movVertical).normalized;

            this.rb2D.MovePosition(this.rb2D.position + this.direction * this.speedMovement * Time.fixedDeltaTime);
            //this.rb2D.MovePosition(this.rb2D.position + this.direction * this.speedMovement/2 * Time.fixedDeltaTime);

            this.movHorizontal = this.movVertical = 0;
        }
    }

    // Indicates if the waiting time between movements has elapsed.
    private bool WaitingTime()
    {
        this.timeElapsed += Time.deltaTime;
        if (this.timeElapsed >= this.waitingTime)
        {
            this.timeElapsed = 0f;
            return true;
        }
        return false;
    }
}
