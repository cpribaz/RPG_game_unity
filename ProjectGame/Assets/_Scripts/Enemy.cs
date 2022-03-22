using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float stoppingDist; 
    [SerializeField] float damage;

    float lastAttackTime = 0;
    float attackCoolDown = 1;

    NavMeshAgent agent;

    GameObject target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < stoppingDist)
        {
            stopEnemy();
            if (Time.time - lastAttackTime >= attackCoolDown)
            {
                lastAttackTime = Time.time;
                target.GetComponent<CharacterStats>().TakeDamage(damage);
            }
        }
        else
        {
            findTarget();
        }
    }

    private void findTarget()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);

    }

    private void stopEnemy()
    {
        agent.isStopped = true;
    }

    private void Attack()
    {
        if (Time.time - lastAttackTime >= attackCoolDown)
        {
            lastAttackTime = Time.time;
            target.GetComponent<CharacterStats>().TakeDamage(damage);
            target.GetComponent<CharacterStats>().CheckHealth();
        }
    }
}
