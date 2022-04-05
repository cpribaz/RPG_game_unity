using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Enemy : MonoBehaviour
{
    //game objects and variables created to be used in code below 
    [SerializeField] float stoppingDist; 
    [SerializeField] float damage;

    //variables for attack cool down time 
    float lastAttackTime = 0;
    float attackCoolDown = 1;

    //objects to allow nav mesh agent to work
    NavMeshAgent agent;
    GameObject target;

    private void Update()
    {
        //target variable set to player object 
        GameObject gameOb = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        target = gameOb.transform.parent.gameObject; 

        //if statement to stop enemy at certain distnace from player
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < stoppingDist)
        {
            stopEnemy();
            if (Time.time - lastAttackTime >= attackCoolDown)
            {
                //buffer for enemy attack on player 
                lastAttackTime = Time.time;
                target.GetComponent<CharacterStats>().TakeDamage(damage);
            }
        }
        else
        {
            findTarget();
        }
    }

    //method for enemy AI to seek out player 
    private void findTarget()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);

    }

    //method to stop enemy at desired distnace 
    private void stopEnemy()
    {
        agent.isStopped = true;
    }

    //method for enemy to attack player 
    private void Attack()
    {
        //buffer to slow attack 
        if (Time.time - lastAttackTime >= attackCoolDown)
        {
            lastAttackTime = Time.time;
            target.GetComponent<CharacterStats>().TakeDamage(damage);
            target.GetComponent<CharacterStats>().CheckHealth();
        }
    }

    


}
