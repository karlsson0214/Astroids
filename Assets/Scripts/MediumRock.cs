using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumRock : Rock
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 4;
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Bullet"))
        {
            Bullet bulletScriptObject = collision.gameObject.GetComponent<Bullet>();
            health -= bulletScriptObject.Damage;
            Destroy(collision.gameObject);
            //Debug.Log("Rock healt: " + health);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
