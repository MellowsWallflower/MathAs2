using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCollision : MonoBehaviour
{
    public float width = 1f;
    public float height = 1f;

    private Color overlapColor = Color.green;
    private Color noOverlapColor = Color.red;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        SetColor(noOverlapColor);
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollisions();
    }

    void CheckCollisions()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject otherObject in allObjects)
        {
            if (otherObject == gameObject || otherObject.CompareTag("MainCamera"))
                continue;

            if (MyCollision.Overlap2D(gameObject, otherObject))
            {
                HandleCollisionResponse(otherObject);
                return;
            }
        }

        SetColor(noOverlapColor);
    }

    void HandleCollisionResponse(GameObject otherObject)
    {
        Debug.Log("Collision with: " + otherObject.name);

        SetColor(overlapColor);

    }

    void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }

    public static bool Overlap1D(float min1, float max1, float min2, float max2)
    {
        return (min2 <= max1 && max1 <= max2) || (min1 <= max2 && max2 <= max1);
    }

    public static bool Overlap2D(
        float xMin1, float xMax1, float yMin1, float yMax1,
        float xMin2, float xMax2, float yMin2, float yMax2)
    {
        return Overlap1D(xMin1, xMax1, xMin2, xMax2) && Overlap1D(yMin1, yMax1, yMin2, yMax2);
    }

    public static bool Overlap2D(GameObject object1, GameObject object2)
    {
        Vector3 position1 = object1.transform.position;
        Vector3 position2 = object2.transform.position;
        float width1 = object1.transform.localScale.x;
        float width2 = object2.transform.localScale.x;
        float height1 = object1.transform.localScale.y;
        float height2 = object2.transform.localScale.y;
        float xMin1 = position1.x - width1 * 0.5f;
        float xMax1 = position1.x + width1 * 0.5f;
        float xMin2 = position2.x - width2 * 0.5f;
        float xMax2 = position2.x + width2 * 0.5f;
        float yMin1 = position1.y - height1 * 0.5f;
        float yMax1 = position1.y + height1 * 0.5f;
        float yMin2 = position2.y - height2 * 0.5f;
        float yMax2 = position2.y + height2 * 0.5f;
        return Overlap2D(xMin1, xMax1, yMin1, yMax1, xMin2, xMax2, yMin2, yMax2);
    }
}
