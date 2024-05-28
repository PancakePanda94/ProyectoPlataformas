using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStomp : MonoBehaviour
{
    // Static counter to keep track of the number of enemies killed
    public static int enemiesKilled = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement player = collision.collider.GetComponent<PlayerMovement>();
        if (collision.gameObject.tag == "Weak Point")
        {
            Destroy(gameObject);
            //player.Regen();
            enemiesKilled++; // Increment the counter when the weak point is hit
        }

        if (player != null)
        {
            Destroy(gameObject.transform.parent.gameObject);
            enemiesKilled++; // Increment the counter when the player destroys the enemy
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
