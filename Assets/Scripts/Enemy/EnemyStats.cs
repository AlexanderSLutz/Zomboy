﻿using UnityEngine;
//SCRIPT BELONGS ON ALL ENEMY PREFABS
//Contains all stats of the enemy
//MORE HERE LATER(movement etc.)
//
public class EnemyStats : MonoBehaviour
{
    //All enemy stats go here
    public int Health = 100;
    public int maxHealth = 100;
    public int movementSpeed = 100;
    public int agroRange = 10;
    public int enemyDamage = 10;
    public int attackRange = 1;
    public int attackSpeed = 1;
    public GameObject healthBar;

    void Start()
    {
        //Instantiate(healthBar, transform.position, transform.rotation);
    }
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
