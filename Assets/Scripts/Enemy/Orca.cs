using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orca : MonoBehaviour
{

    [SerializeField] ParticleSystem waterShot;

    private Transform target;
    //How far away from target
    private float distanceToTarget = Mathf.Infinity;
    private EnemyHealth orcaHealth;

    private float chaseRange = 50f;
    private bool hasStarted = false;

    private float nextShot = 0f;

    private bool readyToFire = false;

    private void Start()
    {
        orcaHealth = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget < chaseRange)
        {
            FaceTarget();
            Invoke("ReadyToFire", 2f);

            if (readyToFire && !orcaHealth.isDead)
            {
                RandomShot();
            }
        }
        else { return; }
    }

    private void ReadyToFire()
    {
        readyToFire = true;
    }

    private void RandomShot()
    {
        float fireRate = Random.Range(1f, 2.5f);

        if(Time.time > nextShot)
        {
            nextShot = Time.time + fireRate;
            waterShot.Play();
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 3f);
    }


}
