using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    float health;

    [SerializeField]
    float bulletDamage;

    enum States {
        idle,
        walking,
        patroll,
        attack,
        die
    }


    public void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        if (health <= 0f) {
            Die();
        }
    }

    public float DealDamage(){
        return bulletDamage;
    }

    void Die(){
        Destroy(gameObject);
    }




}
