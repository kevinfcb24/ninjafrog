using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
     Joystick joy;

    public float runSpeed =2;

    public float jumpSpeed = 3;

    Rigidbody2D rb2D;


    public bool betterJump = false;

    public float fallMultiplier = 0.5f;

    public float lowJumpMultiplier = 1f;

    public SpriteRenderer SpriteRenderer;

    public Animator animator;

    void Start()
    {
        joy = FindObjectOfType<Joystick>();
        rb2D = GetComponent<Rigidbody2D>();

        Screen.SetResolution(1600, 900, false);

    }


    void FixedUpdate()
    {



         if (joy.Horizontal>0)
         {
            rb2D.velocity = new Vector2(runSpeed * 0.5f, rb2D.velocity.y);
            SpriteRenderer.flipX = false;
            animator.SetBool("Run",true);


        }

        else if (joy.Horizontal<0)
         {
            rb2D.velocity = new Vector2(-runSpeed * 0.5f, rb2D.velocity.y);
            SpriteRenderer.flipX = true;
            animator.SetBool("Run",true);
        }
         else 
         {
            rb2D.velocity=new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run",false);

        }
        
        if (Input.GetKey("space") && CheckGround.isGrounded)
         {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
         }

        if (CheckGround.isGrounded==false)
        {
            animator.SetBool("Jump",true);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGrounded==true)
        {
            animator.SetBool("Jump", false);
        }

        if (betterJump)
        {
            /*
            if (rb2D.velocity.y<0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            */

            if (rb2D.velocity.y>0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }


        }
                    
                    
    }



    public void Salto()
    {
        if (CheckGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed * 1.5f);
        }

    }

    public void Salir()
    {
        Application.Quit();
    }


}

