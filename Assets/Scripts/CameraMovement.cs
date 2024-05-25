using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Player.transform.position.x;
        position.y = (float)(Player.transform.position.y+0.07);
        transform.position = position;
    }
}
