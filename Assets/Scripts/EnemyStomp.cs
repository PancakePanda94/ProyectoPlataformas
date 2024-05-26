using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStomp : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement player = collision.collider.GetComponent<PlayerMovement>();
        if (collision.gameObject.tag == "Weak Point")
        {
            Destroy(gameObject);
            
        }

        if (player != null)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
