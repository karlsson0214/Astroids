using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapScreenMover : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected float xMax;
    protected float yMax;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // ouside screen => appear on opposite side
        if (rb.position.x > xMax)
        {
            rb.position = new Vector2(-xMax, rb.position.y);
        }
        else if (rb.position.x < -xMax)
        {
            rb.position = new Vector2(xMax, rb.position.y);
        }
        else if (rb.position.y > yMax)
        {
            rb.position = new Vector2(rb.position.x, -yMax);
        }
        else if (rb.position.y < -yMax)
        {
            rb.position = new Vector2(rb.position.x, yMax);
        }
    }
}
