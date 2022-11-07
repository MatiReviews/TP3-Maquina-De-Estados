using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private float health;

    public void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        if (health <= 0f) {
            Die();
        }
    }
  
    void Die(){
        Destroy(gameObject);
    }




}
