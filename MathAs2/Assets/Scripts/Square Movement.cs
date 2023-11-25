using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    public float speed = 0.0f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = 0.0f;
        float yDir = 0.0f;
        if (Input.GetKey(KeyCode.I))
        {
            yDir = 1.0f;
        }

        else if (Input.GetKey(KeyCode.K))
        {
            yDir = -1.0f;
        }

        else if (Input.GetKey(KeyCode.J))
        {
            xDir = -1.0f;
        }

        else if (Input.GetKey(KeyCode.L))
        {
            xDir = 1.0f;
        }
        rb.velocity = new Vector2(xDir, yDir) * speed;

      
    }

}

