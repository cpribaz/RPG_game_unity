using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //variables created to hold stats     
    public float currHealth;
    public float maxHealth;
    public bool isDead;

    

    //method to check health 
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

   
    //health set 
    private void SetHealthTo(int healthToSetTo)
    {
        currHealth = healthToSetTo;
        CheckHealth();
    }
   
    //take damage method created 
    public void TakeDamage(float damage)
    {
        currHealth -= damage;
    }
}
