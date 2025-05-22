using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : WrapScreenMover
{
    private int damage = 4; 
    // Start is called before the first frame update

    public int Damage
    {
        get 
        { 
            return damage; 
        }
    }
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
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
            Debug.Log("Collision bullet bullet");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
