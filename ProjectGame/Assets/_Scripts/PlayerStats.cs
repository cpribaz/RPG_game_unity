using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : CharacterStats
{
    PlayerHUD playerHUD;
    //game objects created to be used in unity editor 
    public GameObject player;
    public GameObject loseText;
    public GameObject skeleton1;
    public GameObject skeleton2;
    public GameObject skeleton3;
    public GameObject zombie1;
    public GameObject zombie2;

    public int count;
    public TextMeshProUGUI scoreText;
    


    private void Start()
    {
        //game scene set up in start method 
        playerHUD = GetComponent<PlayerHUD>();

        maxHealth = 100;
        currHealth= maxHealth;
        count = 0;
        SetStats();
        SetScoreText();
        loseText.SetActive(false);
        
    }
    private void Update()
    {
        //certain functions called every frame 
        CheckHealth();
        SetScoreText();
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
    void SetScoreText()
    {
        scoreText.text = "Score: " + count.ToString();
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
        
        if(other.gameObject.CompareTag("Skeleton"))
        {
            count += 5;
        }
        if (other.gameObject.CompareTag("Zombie"))
        {
            count += 1;
        }
    }

    private void updateScore()
    {
            if (isDestroyed(skeleton1) || isDestroyed(skeleton2) || isDestroyed(skeleton3))
            {
                count += 2; 
            }

            if (isDestroyed(zombie1) || isDestroyed(zombie2))
            {
                count++;
            }
    }
    private bool isDestroyed(GameObject enemy)
    {
        return enemy == null && !ReferenceEquals(enemy, null);
    }
}
