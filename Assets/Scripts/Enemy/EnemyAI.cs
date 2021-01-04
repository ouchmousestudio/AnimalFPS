using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [Tooltip("Distance before chase starts.")]
    [SerializeField] float agroRange = 10f;
    [Tooltip("Distance to escape.")]
    [SerializeField] float escapeRange = 30f;
    [SerializeField] float turnSpeed = 3f;
    [SerializeField] float stoppingDistance = 0f;
    [SerializeField] bool isAfraid;

    NavMeshAgent navMeshAgent;
    Transform target;

    //How far away from target
    float distanceToTarget = Mathf.Infinity;

    bool isProvoked = false;
    EnemyHealth health;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
        health = GetComponent<EnemyHealth>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        //navMeshAgent.stoppingDistance = stoppingDistance;
    }

    void Update()
    {
        if (health.isDead)
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        else
        {
            distanceToTarget = Vector3.Distance(target.position, transform.position);

            if (isProvoked)
            {
                EngageTarget();
            }
            else if (distanceToTarget < agroRange)
            {
                isProvoked = true;
            }
            else if (distanceToTarget > escapeRange)
            {
                isProvoked = false;
            }
        }
    }

    private void EngageTarget()
    {
        if (!isAfraid)
        {
            FaceTarget();
            //chase target based on chase range variable
            if (distanceToTarget >= navMeshAgent.stoppingDistance)
            {
                ChaseTarget();
            }

            else if (distanceToTarget <= navMeshAgent.stoppingDistance)
            {
                AttackTarget();
            }
        }
        else
        {
            RunFromTarget();
        }
    }

    //Ensure enemy faces the target even during the atack phase.
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        navMeshAgent.isStopped = true;
    }

    private void ChaseTarget()
    {
        //Start move animation and reset attack animation
        GetComponent<Animator>().SetBool("isAttacking", false);
        navMeshAgent.isStopped = false;
        //GetComponent<Animator>().SetTrigger("move");
        GetComponent<Animator>().SetBool("isRunning", true);
        navMeshAgent.SetDestination(target.position);
    }

    private void RunFromTarget()
    {
        GetComponent<Animator>().SetBool("isRunning", true);
        Vector3 direction = transform.position - target.transform.position;
        Vector3 newPos = transform.position + direction;
        navMeshAgent.SetDestination(newPos);

    }

    // Show chase range in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agroRange);
    }
}
