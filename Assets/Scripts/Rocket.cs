using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Sprite rocket;
    [SerializeField] private Sprite rocketWithFlame;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float xMax;
    private float yMax;
    private float rotationSpeed = 120f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        // camera center to top of screen in world coordinates
        yMax = Camera.main.orthographicSize;
        xMax = yMax * Camera.main.aspect;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // forward
            rb.AddForce(transform.right);
            sr.sprite = rocketWithFlame;
        }
        else
        {
            sr.sprite = rocket;

        }
        if (Input.GetKey(KeyCode.A))
        {
            // turn left
            rb.SetRotation(rb.rotation + rotationSpeed * Time.deltaTime); 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // turn right
            rb.SetRotation(rb.rotation - rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            // shoot
        }

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
