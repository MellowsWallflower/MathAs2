using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force_script : MonoBehaviour
{
    public float jumpHeight = 5;
    public float gravityScale = 5;
    

    float velocity;

    float floorHeight = 0.5f;
    Transform feet;
    ContactFilter2D filter;
    bool isGrounded;
    Collider2D[] results = new Collider2D[1];
    
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        velocity += Physics2D.gravity.y * gravityScale * Time.deltaTime;

        if (Physics2D.OverlapBox(feet.position, feet.localScale, 0, filter, results) > 0 && velocity < 0)
        {
            velocity = 0;
            Vector2 surface = Physics2D.ClosestPoint(transform.position, results[0]) + Vector2.up * floorHeight;
            transform.position = new Vector3(transform.position.x, surface.y, transform.position.z);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (Input.GetMouseButtonDown(1) && isGrounded)
        {
            velocity = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * gravityScale));
        }
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    }


}
