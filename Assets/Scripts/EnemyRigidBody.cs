//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyRigidBody : MonoBehaviour
//{
//    private Rigidbody2D rb;
//    public GameObject pointA;
//    public GameObject pointB;
//    private Animator anim;
//    private Transform currentPoint;
//    public float speed;
    
//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        anim = GetComponent<Animator>();
//        currentPoint = pointB.transform;
//        anim.SetBool("isRunning", true);
//    }

//    // Update is called once per frame
//    void Update()
//    {

//        Vector2 point = currentPoint.position - transform.position;
//        if (currentPoint == pointB.transform)
//        {
//            rb.velocity = new Vector2(-speed, 0);

//        }
//        else
//        {
//            rb.velocity = new Vector2(speed, 0);
//        }

//        if (Vector2.Distance(transform.position, currentPoint.position) < 0.15f && currentPoint == pointA.transform)
//        {
//            currentPoint = pointB.transform;
//        }

//        if (Vector2.Distance(transform.position, currentPoint.position) < 0.15f && currentPoint == pointB.transform)
//        {
            
//            currentPoint = pointA.transform;
//        }


//    }

//    private void OnDrawGizmos()
//    {
//        Gizmos.DrawWireSphere(pointA.transform.position, 0.15f);
//        Gizmos.DrawWireSphere(pointB.transform.position, 0.15f);
//        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
//    }
//}
