using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    // Start is called before the first frame update
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
        Animator.SetBool("PlayerGrounded", Grounded);
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Animator.SetBool("PlayerMovement", Horizontal != 0.0f);
        Debug.DrawRay(transform.position, Vector3.down * 0.125f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.125f)) 
        Grounded = true;
        else Grounded = false;
        
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            
            Jump();
        }
    }

    private void Jump()
    {
        
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
        
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }
}