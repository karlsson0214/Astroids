using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D rb;
    private float xMax;
    private float yMax;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // camera center to top of screen in world coordinates
        yMax = Camera.main.orthographicSize;
        xMax = yMax * Camera.main.aspect;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.right);
        }
        if (Input.GetKey(KeyCode.A))
        {
            // turn left
            rb.SetRotation(rb.rotation + 120f * Time.deltaTime); 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // turn right
            rb.SetRotation(rb.rotation - 120f * Time.deltaTime);
        }
        if (rb.position.x > xMax)
        {
            rb.position = new Vector2(-xMax, rb.position.y);
        }
        
    }
}
