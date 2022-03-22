using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    PlayerHUD playerHUD;

    private void Start()
    {
        playerHUD = GetComponent<PlayerHUD>();

        maxHealth = 100;
        currHealth= 100;

        
    }
    private void Update()
    {
        CheckHealth();
    }
    public override void Die()
    {
        Debug.Log("You Died");
        
    }
    
    void SetStats()
    {
        playerHUD.healthAmount.text = currHealth.ToString();
        playerHUD.healthAmount.text = maxHealth.ToString();
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
        SetStats();
    }
}
