using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float velocity = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        X_Move();
        Y_Move();
    }

    void X_Move()
    {
        Vector3 movedirection = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            movedirection = Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            movedirection = Vector3.right;
        }

        transform.position += movedirection * velocity * Time.deltaTime;
    }

    void Y_Move()
    {
        Vector3 movedirection = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            movedirection = Vector3.up;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            movedirection = Vector3.down;
        }

        transform.position += movedirection * velocity * Time.deltaTime;
    }
}
