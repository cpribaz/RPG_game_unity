using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public GameObject enemy;
    float lastAttackTime = 0;
    float attackCoolDown = 1;

    private void Start()
    {
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
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Mouse0))
        {
            currHealth -= 10;
        }
        if (other.gameObject.CompareTag("Player") && !Input.GetKeyDown(KeyCode.Mouse0))
        {
            currHealth -= 2;
        }
        /*
        if (Time.time - lastAttackTime >= attackCoolDown)
        {
            lastAttackTime = Time.time;
            TakeDamage(other);

        }
        */
        //this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }
    /*
    private void OnTriggerExit(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }
    */
}
