using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : WrapScreenMover
{
    private int health = 16;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        float xSpeed = Random.Range(0f, 1f);
        float ySpeed = Random.Range(0f, 1f);
        rb.velocity = new Vector2 (xSpeed, ySpeed);


    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Bullet"))
        {
            Bullet bulletScriptObject = collision.gameObject.GetComponent<Bullet>();
            health -= bulletScriptObject.Damage;
            Destroy(collision.gameObject);
            Debug.Log("Rock healt: " + health);
        }
        
    }
}
