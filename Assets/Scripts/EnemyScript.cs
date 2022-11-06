using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    float health;

    enum States{
        idle,
        walking,
        patroll,
        attack,
        die
    }


    public void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        if (health <= 0f){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }



}
