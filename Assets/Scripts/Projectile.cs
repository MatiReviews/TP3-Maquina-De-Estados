using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public static float damage;
    float radious;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Player.TakeDamage(10f);
            Destroy(gameObject);
        }                   
        
        Destroy(gameObject,2f);        
    }
}
