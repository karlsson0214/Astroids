using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : WrapScreenMover
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Sprite rocket;
    [SerializeField] private Sprite rocketWithFlame;
    [SerializeField] private float bulletForce = 100;

    private SpriteRenderer sr;

    private float rotationSpeed = 120f;
    private Transform gunTransform;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        // camera center to top of screen in world coordinates
        yMax = Camera.main.orthographicSize;
        xMax = yMax * Camera.main.aspect;
        gunTransform = transform.Find("Gun");

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // shoot
            GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, transform.rotation);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            // forward
            rbBullet.AddForce(transform.right * bulletForce);
        }

       
        
    }
}
