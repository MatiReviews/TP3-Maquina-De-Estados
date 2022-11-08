using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    static float health;
    static float oldHealth;

    public static bool isGameOver;
    bool isDead;

    public TextMeshProUGUI playerHPText;

    PlayerSound myPlayerSound;


    // Start is called before the first frame update
    void Start(){
        health = 200;
        oldHealth = 200;
        isGameOver = false;
        myPlayerSound = GetComponent<PlayerSound>();
    }

    // Update is called once per frame
    void Update(){
       Debug.Log("Health: " + GetHealth());
        playerHPText.text =  GetHealth().ToString();
        if (isGameOver){

        }

        if (health != oldHealth){
            oldHealth = health;
            myPlayerSound.DamageSound();
        }
    }

    public float GetHealth(){
        return health;
    }

    public static void TakeDamage(float damage){
        health -= damage;
    }

    public void Dead(){
        if(health <= 0f){
            isGameOver = true;
        }
    }
}
