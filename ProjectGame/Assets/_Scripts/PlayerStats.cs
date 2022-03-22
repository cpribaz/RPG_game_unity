using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    PlayerHUD playerHUD;
    public GameObject player;

    public GameObject loseText;

    private void Start()
    {
        playerHUD = GetComponent<PlayerHUD>();

        maxHealth = 100;
        currHealth= maxHealth;

        SetStats();

        loseText.SetActive(false);
        
    }
    private void Update()
    {
        CheckHealth();
        if(isDead == true)
        {
            loseText.SetActive(true);
        }
    }
    public override void Die()
    {
        Debug.Log("You Died");
        
    }
    
    void SetStats()
    {
        playerHUD.healthAmount.text = currHealth.ToString();
        playerHUD.maxHealthAmount.text = maxHealth.ToString();
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
        SetStats();
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;
        SetStats();
    }
}
