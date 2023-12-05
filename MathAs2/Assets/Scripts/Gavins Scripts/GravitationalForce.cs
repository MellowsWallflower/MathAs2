using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalForce : MonoBehaviour
{
    public float Gravity = 9.8f;
    public float Mass;
    public float Velocity;
    float Resistance = 0;
    public GameObject Ground;


    // Start is called before the first frame update
    void Start()
    {
        

    }
    private void Fall()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - Velocity);
    }

    // Update is called once per fram
    void Update()
    {
        Ground.transform.position = new Vector2(gameObject.transform.position.x, Ground.transform.position.y);
        if (gameObject.transform.position.y > Ground.transform.position.y + Ground.transform.localScale.y)
        {
            Fall();
            Velocity = Mathf.Clamp(Resistance, 0, Gravity) * Mass * Time.deltaTime;
            Resistance += 0.1f;

        }
        else if (gameObject.transform.position.y <= Ground.transform.position.y + Ground.transform.localScale.y)
        {

               Velocity = 0;
            
        }
        
    }
}
