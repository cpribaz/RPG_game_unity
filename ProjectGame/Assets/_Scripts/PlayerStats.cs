using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    PlayerHUD playerHUD;
    //game objects created to be used in unity editor 
    public GameObject player;
    public GameObject loseText;

    

    private void Start()
    {
        //game scene set up in start method 
        playerHUD = GetComponent<PlayerHUD>();

        maxHealth = 100;
        currHealth= maxHealth;

        SetStats();

        loseText.SetActive(false);
        
    }
    private void Update()
    {
        //certain functions called every frame 
        CheckHealth();
        if(isDead == true)
        {
            loseText.SetActive(true);
        }
    }
    
    //method to track player stats 
    void SetStats()
    {
        playerHUD.healthAmount.text = currHealth.ToString();
        playerHUD.maxHealthAmount.text = maxHealth.ToString();
    }

    //method to check player health
    public override void CheckHealth()
    {
        base.CheckHealth();
        SetStats();
    }

    //method to allow player to take damage 
    public void TakeDamage(float damage)
    {
        currHealth -= damage;
        SetStats();
    }

    //method to detect when player contacts pick up orb 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            //increase players health
            other.gameObject.SetActive(false);
            currHealth += 5;
        }
    }
}
