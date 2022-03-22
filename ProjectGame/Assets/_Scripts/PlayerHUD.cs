using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public Text healthAmount;
    public Text maxHealthAmount;

    CharacterStats playerStats;

    private void Start()
    {
        playerStats = GetComponent<CharacterStats>();
        
    }

    private void Update()
    {
        SetStats();
        playerStats = GetComponent<CharacterStats> ();

    }
    public void TakeDamage(float damage)
    {
        playerStats.currHealth -= damage;
        SetStats();
    }

    void SetStats()
    {
        healthAmount.text = playerStats.currHealth.ToString();
        maxHealthAmount.text = playerStats.maxHealth.ToString();
    }

    
    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        healthAmount.text = currentHealth.ToString();
        maxHealthAmount.text = maxHealth.ToString();
    }
    
    
}
