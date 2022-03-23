using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    //game objects created to show health stats 
    public Text healthAmount;
    public Text maxHealthAmount;

    CharacterStats playerStats;

    private void Start()
    {
        //scene set in start 
        playerStats = GetComponent<CharacterStats>();
        
    }

    private void Update()
    {
        //method to be checked every frame 
        SetStats();
        playerStats = GetComponent<CharacterStats> ();

    }

    //take damage method to change player health 
    public void TakeDamage(float damage)
    {
        playerStats.currHealth -= damage;
        SetStats();
    }

    //set stats to update player health 
    void SetStats()
    {
        healthAmount.text = playerStats.currHealth.ToString();
        maxHealthAmount.text = playerStats.maxHealth.ToString();
    }
    
    
}
