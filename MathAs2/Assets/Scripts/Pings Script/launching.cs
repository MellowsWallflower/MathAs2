using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launching : MonoBehaviour
{
    public float Gravity = -9.8f;
    public float Mass;
    public float Velocity;
    float Resistance = 0;
    public GameObject Ground;
    public static bool CeilingTouched;

    // Start is called before the first frame update
    void Start()
    {


    }
    private void Launch()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - Velocity);
    }

    // Update is called once per fram
    void Update()
    {
        Ground.transform.position = new Vector2(gameObject.transform.position.x, Ground.transform.position.y);
        if (Input.GetMouseButtonDown(0))
        {
            CeilingTouched = false;
        }
        if (gameObject.transform.position.y <= Ground.transform.localScale.y && CeilingTouched == false)
        {
           
            Launch();
            Velocity = Mathf.Clamp(Resistance, 0, Gravity) * Mass * Time.deltaTime;
            Mass += 0.1f;
            Resistance += 0.1f;
            Debug.Log("launch from ground velocity: " + Velocity);
        }
        else if(gameObject.transform.position.y <= 5 && CeilingTouched == false)
        {
            Launch();
            Velocity = Mathf.Clamp(Resistance, 0, Gravity) * Mass * Time.deltaTime;
            Mass += 0.1f;
            Resistance += 0.1f;
            Debug.Log("from air: " + Velocity);
        }
        else if (gameObject.transform.position.y >= 5)
        {
            CeilingTouched = true;
            Velocity = 0;

        }
        Debug.Log("launch velocity: " + Velocity);
        Debug.Log("gameobject y:" + gameObject.transform.position.y);
        Debug.Log("gameobject ground: " + Ground.transform.position.y);
        Debug.Log("gameObject localscale : " + Ground.transform.localScale.y);
       

    }
}
