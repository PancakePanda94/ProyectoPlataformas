using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumMovement : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(-speed, 0);

        }
        else
        {
            rb.velocity = new Vector2(speed, 0);
        }

        

        if(Vector2.Distance(transform.position,currentPoint.position)<0.15f && currentPoint == pointA.transform)
        {
            FlipSprite();
            currentPoint = pointB.transform;    
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.15f && currentPoint == pointB.transform)
        {
            FlipSprite();
            currentPoint = pointA.transform;
        }
    }

    private void FlipSprite()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.15f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.15f);
        Gizmos.DrawLine(pointA.transform.position,pointB.transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement player = collision.collider.GetComponent<PlayerMovement>();
        OpossumMovement opossum = collision.collider.GetComponent<OpossumMovement>();

        if(collision.collider.CompareTag("Weak Point"))
        {
            Stomp();
            
        }
        else
        {
            if (player != null)
            {
                player.Hit();
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weak Point"))
        {
            // Handle stomp detection
            print("Enemy stomped by player.");
            Debug.Log("Enemy stomped by player.");
            Stomp();
        }
    }

    private void Stomp()
    {
        Destroy(gameObject);
    }
}
