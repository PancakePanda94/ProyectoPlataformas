using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private int Health = 3;
    private int MaxHealth = 3;
    public SpriteRenderer playerSr;
    
    // Start is called before the first frame update
    //aa
    void Start()
    {
        Rigidbody2D=GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Animator.SetBool("PlayerJumping", (Rigidbody2D.velocity.y > 0 && !Grounded));
        Animator.SetBool("PlayerFalling", (Rigidbody2D.velocity.y < 0 && !Grounded));
        //print(Rigidbody2D.velocity.y);
        LayerMask groundLayer = LayerMask.GetMask("Ground");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("PlayerMovement", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.145f, Color.red);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.145f, groundLayer))
         Grounded = true;
        else  Grounded = false; 
       //print(Grounded);

        Animator.SetBool("PlayerGrounded", Grounded);
        //if (Physics2D.Raycast(transform.position, Vector3.down, 0.12f))
        //    Grounded = true;
        //else Grounded = false;

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            
            Jump();
        }

    }
    public int getHealth()
    {
        return Health;
    }

    public int getMaxHealth()
    {
        return MaxHealth;
    }
        
    private void Jump()
    {
        
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
        
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }

    public void Hit()
    {
        Health--;
        if(Health <= 0)
        {
            playerSr.enabled = false;
            Speed = 0;
            this.enabled = false;
        }
    }
}
