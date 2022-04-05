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
    public GameObject level1WinText;
    public GameObject skeleton1;
    public GameObject skeleton2;
    public GameObject skeleton3;
    public GameObject zombie1;
    public GameObject zombie2;

    public int count;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI LevelNumText;

    public GameObject upgradeText;
    public GameObject winText;

    public GameObject door;

    public int level;

    public GameObject boss;

    private void Start()
    {
        //game scene set up in start method 
        playerHUD = GetComponent<PlayerHUD>();

        maxHealth = 100;
        currHealth= maxHealth;
        count = 0;
        level = 1;
        SetStats();
        SetScoreText();
        SetLevelText();
        loseText.SetActive(false);
        level1WinText.SetActive(false);
        upgradeText.SetActive(false);
        boss.SetActive(false);
        winText.SetActive(false);
        
    }
    private void Update()
    {
        //certain functions called every frame 
        CheckHealth();
        SetScoreText();
        SetLevelText();
        if(isDead == true)
        {
            loseText.SetActive(true);
        }
        
        if(count >= 15)
        {
            Destroy(door);
            boss.SetActive(true);
            level1WinText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.P))
            {
                count = 0;
                level = 2;
                level1WinText.SetActive(false);
                upgradeText.SetActive(true);
                maxHealth = 110;
               
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            upgradeText.SetActive(false);
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
    void SetLevelText()
    {
        LevelNumText.text = "Level: " + level.ToString();
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
        if (other.gameObject.CompareTag("greenScore"))
        {
            count += 4;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("zomScore"))
        {
            count += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("gameWin"))
        {
            winText.SetActive(true);
            Destroy(other.gameObject);
        }

    }

    
    
}
