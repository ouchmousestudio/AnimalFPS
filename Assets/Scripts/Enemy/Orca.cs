using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orca : MonoBehaviour
{

    [SerializeField] GameObject bossHealthUI;
    [SerializeField] AudioSource bossTheme;
    [SerializeField] ParticleSystem waterShot;
    [SerializeField] EnemyHealth orcaHealth;

    Transform target;
    //How far away from target
    private float distanceToTarget = Mathf.Infinity;

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

            if (hasStarted == false)
            {
                hasStarted = true;
                bossHealthUI.SetActive(true);
                bossTheme.Play();
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

    private void OnDisable()
    {
        if (bossHealthUI != null) { bossHealthUI.SetActive(false); }
        if (bossTheme != null) { bossTheme.Stop(); }   
    }

}
