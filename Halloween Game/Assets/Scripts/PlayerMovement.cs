using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private SpriteRenderer sprite;
    private float dirHori = 0f;
    [SerializeField] private float moveSpeed = 7f; //[SerializeField] lets you edit value in the unity editor
    //[SerializeField] private float acceleration = 0.1f;
    //[SerializeField] private float decceleration = 0.05f;
    [SerializeField] private float jumpForce = 13f;
    private float xMove = 0f;
    private bool inAir = false;
    private bool isJumping = false;
    private float hitForce = 6f;

    float animateTime = 0f;
    float animateTimeMax = 1.5f;

    //Audio add in
    [SerializeField] private AudioSource jumpSoundEffect;

    private enum MovementState
    {
        idle,
        run,
        jump,
        fall
    }

    // Start is called before the first frame update
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        //anim = GetComponent<Animator>();
        sprite = GameObject.Find("PlayerSprite").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirHori = Input.GetAxisRaw("Horizontal"); //GetAxisRaw (as opposed to GetAxis()) drops axis to 0 immediately (makes player stop moving after release)

        if (dirHori != 0)
        {
            xMove = dirHori * moveSpeed;
            //xMove = Mathf.MoveTowards(xMove, dirHori * moveSpeed, acceleration);
        }
        else
        {
            // slow to a stop
            xMove = 0f;
            //xMove = Mathf.MoveTowards(xMove, 0f, decceleration);
        }

        //rb.velocity = new Vector2(xMove * Time.deltaTime, rb.velocity.y); // create movement vector based on axis input
        rb.velocity = new Vector2(xMove, rb.velocity.y); // create movement vector based on axis input


        if (IsGrounded())
        {
            if (inAir)
            {
                animateSquash();
                inAir = false;
            }
        }
        else inAir = true;

        if (Input.GetButtonDown("Jump") && !inAir)
        {
            StartJump();
        }

        // Variable jump height code
        if (isJumping) 
        {
            if (rb.velocity.y >= 0f && !Input.GetButton("Jump"))
            {
                // cut player y velocity if jump key is released and still moving upwards
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2);
                EndJump();
            }
            else if (rb.velocity.y <= 0f && !inAir)
            {
                EndJump();
            }
        }

        

        animateStep();

    }

    public void StartJump()
    {
        animateStretch();
        isJumping = true;
        // Debug.Log("JUMP START");
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //play jump effect
        jumpSoundEffect.Play();
    }
    // Ends player jump and increases gravity
    public void EndJump()
    {
        isJumping = false;
        // Debug.Log("JUMP END");
    }

    // Launches player upwards slightly on hazard collision
    public void hitJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, hitForce);
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        // Animation
        if (dirHori < 0f) // Running left
        {
            sprite.flipX = true;
            state = MovementState.run;
        }
        else if (dirHori > 0f) // Running right
        {
            sprite.flipX = false;
            state = MovementState.run;
        }
        else // Idle
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f) // Jumping up
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -0.1f) // Falling down
        {
            state = MovementState.fall;
        }

        // Sets animation state variable within Unity
        //anim.SetInteger("state", (int)state);
    }

    private void animateStep()
    {
        animateTime += Time.deltaTime;
        Vector3 currentSize = sprite.transform.localScale;
        Vector3 targetSize = new Vector3(1f, 1f, currentSize.z);
        sprite.transform.localScale = Vector3.Lerp(currentSize, targetSize, animateTime/animateTimeMax);
    }

    private void animateStretch()
    {
        animateTime = 0f;
        sprite.transform.localScale = new Vector3(0.7f, 1.3f, sprite.transform.localScale.z);
    }

    private void animateSquash()
    {
        animateTime = 0f;
        sprite.transform.localScale = new Vector3(1.3f, 0.7f, sprite.transform.localScale.z);
    }

    private bool IsGrounded()
    {
        // returns true if collision with jumpableGround LayerMask is found
        bool check = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        return check;
    }
}
