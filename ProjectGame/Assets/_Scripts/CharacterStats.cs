using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
        
    public float currHealth;
    public float maxHealth;

    public bool isDead;

    

    public virtual void CheckHealth()
    {
        if(currHealth >= maxHealth)
        {
            currHealth = maxHealth;
        }
        if(currHealth <= 0)
        {
            currHealth = 0;
            isDead = true;
        }

    }

    public virtual void Die()
    {
        //override 
    }

   
    private void SetHealthTo(int healthToSetTo)
    {
        currHealth = healthToSetTo;
        CheckHealth();
    }
   

    public void TakeDamage(float damage)
    {
        currHealth -= damage;
        
    }

    /*
    public void Heal(int heal)
    {
        int healthAfterHeal = (int)(currHealth + heal);
        SetHealthTo(healthAfterHeal);
    }

    public void InitVariable()
    {
        maxHealth = 100;
        SetHealthTo((int)maxHealth);
        isDead = false;
    }
    */
}
