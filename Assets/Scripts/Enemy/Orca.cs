using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orca : MonoBehaviour
{

    [SerializeField] GameObject bossHealthUI;

    Transform target;
    //How far away from target
    float distanceToTarget = Mathf.Infinity;

    float chaseRange = 50f;

    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        {
            distanceToTarget = Vector3.Distance(target.position, transform.position);

            if (distanceToTarget < chaseRange)
            {
                FaceTarget();
                bossHealthUI.SetActive(true);
            }
            else { return; }
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 3f);
    }
}
