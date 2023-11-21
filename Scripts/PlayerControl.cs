using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer rb_sprite;

    public float horizontal;

    public float runSpeed = 6.0f;
    public float jumpSpeed = 9.0f;

    public Transform groundCheck;
    public LayerMask groundMask;

    public bool isRunner;
    public bool isSpinning;

    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb_sprite = GetComponent<SpriteRenderer>();
        anim= GetComponent<Animator>();
        isSpinning = false;
        isRunner = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (!isRunner)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            horizontal = 0;
            
        }

        if (isRunner && !isSpinning)
        {
            anim.SetInteger("animValue", 1);
            anim.SetBool("isSpin",false);
        }
        else if (isRunner && isSpinning)
        {
            anim.SetBool("isSpin", true);
        }

        if (horizontal == -1)
        {
            rb_sprite.flipX = true;
        }
        else if (horizontal == 1)
        { rb_sprite.flipX = false; }
    
        if(Input.GetKeyDown(KeyCode.W) && IsGround() && !isRunner) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0 && IsGround() && !isRunner)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed*0.5f);
        }

        if (Input.GetKeyDown(KeyCode.W) && IsGround() && isRunner)
        {
            rb.velocity = new Vector2(0, jumpSpeed);
        }

        if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0 && IsGround() && isRunner)
        {
            rb.velocity = new Vector2(0, jumpSpeed * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.S) && isRunner)
        {
            rb.gravityScale = 6;
            isSpinning = true;
        }

        if (IsGround() && isRunner)
        {
            rb.gravityScale = 1;
        }

        if (!isRunner&&horizontal == 0)
        {
            anim.SetInteger("animValue", 0);
        }
        else
        {
            anim.SetInteger("animValue", 1);
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * runSpeed, rb.velocity.y);
    }

    private bool IsGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundMask);
    }

    public void StopRun()
    {
        if (horizontal == 0)
        {
            anim.SetInteger("animValue", 0);
        }
    }

    public void StopSpin()
    {
        isSpinning = false;
    }
}
