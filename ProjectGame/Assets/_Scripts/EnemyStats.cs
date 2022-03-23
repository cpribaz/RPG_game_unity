using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyStats : CharacterStats
{
    public GameObject enemy;

    public TextMeshProUGUI scoreText;

    private int count;

    private void Start()
    {
        count = 0;
        SetScoreText();
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
        CheckHealth();
        if (isDead == true)
        {
            Destroy(enemy);
            if (enemy.CompareTag("Skeleton"))
            {
                count += 2;
                SetScoreText();
            } else if (enemy.CompareTag("Zombie"))
            {
                count += 1;
                SetScoreText();
            }
        }
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
    }

    public void TakeDamage(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Mouse0))
        {
            currHealth -= 10;
        }
        if (other.gameObject.CompareTag("Player") && !Input.GetKeyDown(KeyCode.Mouse0))
        {
            currHealth -= 2;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.Mouse0))
        {
            currHealth -= 10;
        }
        
        if (other.gameObject.CompareTag("Player") && !Input.GetKey(KeyCode.Mouse0))
        {
            currHealth -= 0;
        }
        
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + count.ToString();
    }
}
