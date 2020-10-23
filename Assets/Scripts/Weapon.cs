using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon: MonoBehaviour
{
    [SerializeField] Camera PlayerCamera;
    [SerializeField] float maxRange = 100f;
    [SerializeField] float damage = 30f;
    [Tooltip("Fire rate in seconds")]
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitFX;

    float lastShot = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Time.time > fireRate + lastShot)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            GetComponent<Animator>().SetTrigger("isFired");
            lastShot = Time.time;
        }
           
        
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, maxRange))
        {
            CreateImpact(hit);
            //Todo: Add Hit effect for visual
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);

        }
        else
        {
            return;
        }
    }

    private void CreateImpact(RaycastHit hit)
    {
        //Instantiate Hit effect with rotation from shot direction
        GameObject impact = Instantiate(hitFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
