using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : EnemyScript
{ 
    static float damage;  

    private void Start()
    {
        check();
    }

    void check()
    {
        if(gameObject.tag == "Bullet-Red")
        {
            damage = 10f;
        }
        else if (gameObject.tag == "Bullet-Blue")
        {
            damage = 20f;
        }
        else if (gameObject.tag == "Bullet-Green")
        {
            damage = 25f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Player.TakeDamage(damage);         
            Destroy(gameObject);
        }                   
        
        Destroy(gameObject,1f);
    }
}
