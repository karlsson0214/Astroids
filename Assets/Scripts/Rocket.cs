using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : WrapScreenMover
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Sprite rocket;
    [SerializeField] private Sprite rocketWithFlame;
    [SerializeField] private float bulletForce = 1000;
    [SerializeField] private float bulletSpeed = 10;

    private SpriteRenderer sr;

    private float rotationSpeed = 120f;
    private Transform gunTransform;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
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
            // unity vector pointing forward
            Vector2 forward = new Vector2(transform.right.x, transform.right.y);
            Debug.Log("forward: " + forward.x + ", " + forward.y);
            Debug.Log("velocity: " + rb.velocity.x + ", " + rb.velocity.y);
            rbBullet.velocity = rb.velocity + forward * bulletSpeed;
            Debug.Log("bullet speed: " + rbBullet.velocity);
            // forward
            //rbBullet.AddForce(transform.right * bulletForce);
        }

       
        
    }
}
