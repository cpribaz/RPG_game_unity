using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyStats : CharacterStats
{
    //game objects and variables created to be used in below code 
    public GameObject enemy;
    public int swordDamage = 10;
    public int chargeDamage = 2;

    

    private void Start()
    {
        //scene and values set in start function 
        
        if(enemy.gameObject.tag == "Skeleton")
        {
            maxHealth = 30;
            currHealth = maxHealth;
        }

        if(enemy.gameObject.tag == "Zombie")
        {
            maxHealth = 10;
            currHealth = maxHealth;
        }
    }

    private void Update()
    {
        //methods checked every frame in update 
        CheckHealth();
        
        if (isDead == true)
        {
            Destroy(enemy);
            
        }
    }

    //method overriden from character stats class to check health
    public override void CheckHealth()
    {
        base.CheckHealth();
    }

    
    //method to detect collision between player and enemy 
    private void OnTriggerEnter(Collider other)
    {
        //if statements for two different combat styles 
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.Mouse0))
        {
            currHealth -= swordDamage;
        }
        
        if (other.gameObject.CompareTag("Player") && !Input.GetKey(KeyCode.Mouse0))
        {
            currHealth -= chargeDamage;
        }

    }

    
}
