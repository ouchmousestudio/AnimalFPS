using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [Tooltip("Object to follow (usually Player).")]
    [SerializeField] Transform target;
    [Tooltip("Distance before chase starts.")]
    [SerializeField] float chaseRange = 10f;
    [Tooltip("Distance to escape.")]
    [SerializeField] float escapeRange = 30f;
    [SerializeField] float turnSpeed = 3f;



    NavMeshAgent navMeshAgent;

    //How far away from target
    float distanceToTarget = Mathf.Infinity;

    bool isProvoked;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget < chaseRange)
        {
            isProvoked = true;
        }
        else if (distanceToTarget > escapeRange)
        {
            isProvoked = false;
        }
        
    }

    private void EngageTarget()
    {
        FaceTarget();

        //chase taget based on chase range variable
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        
        else if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        Debug.Log("IS ATTACKING!)");
        GetComponent<Animator>().SetBool("isAttacking", true);
    }

    private void ChaseTarget()
    {
        //Start move animation and reset attack animation
        GetComponent<Animator>().SetBool("isAttacking", false);
        //GetComponent<Animator>().SetTrigger("move");
        GetComponent<Animator>().SetBool("isWalking", true);
        navMeshAgent.SetDestination(target.position);
    }

    //Ensure enemy faces the target even during the atack phase.
    private void FaceTarget()
    {

        Vector3 direction = (target.position - transform.position).normalized;
        //Currently 0 Y axis rotation
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        //transform.rotation = where the target is, we'll roatate at a certain speed
    }

    void OnDrawGizmosSelected()
    {
        // Show chase range in editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
