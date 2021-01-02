using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon: MonoBehaviour
{
    [SerializeField] Camera PlayerCamera;
    [SerializeField] float maxRange = 100f;
    public float damage = 30f;
    [Tooltip("Fire rate in seconds")]
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem laserBeam;
    [SerializeField] GameObject hitFX;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] Slider ammoSlider;
    [SerializeField] AmmoType ammoType;

    float lastShot = 0f;
    public bool isAlive = true;

    private void OnEnable()
    {
        //Display Ammo count in UI
        ammoSlider.value = ammoSlot.GetCurrentAmmo(ammoType) / 30f;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && isAlive) 
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo(ammoType) >= 1)
        {
            if (Time.time > fireRate + lastShot)
            {
                PlayMuzzleFlash();
                laserBeam.Emit(1);

                //ProcessRaycast();

                ammoSlot.ReduceCurrentAmmo(ammoType);
                //Display Ammo count in UI
                ammoSlider.value = ammoSlot.GetCurrentAmmo(ammoType) / 30f;
                GetComponent<Animator>().SetTrigger("isFired");
                lastShot = Time.time;
            }
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }


    //Replaced with OnParticleCollision script

    //private void ProcessRaycast()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, maxRange))
    //    {
    //        CreateImpact(hit);
    //        EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
    //        if (target == null) return;
    //        target.TakeDamage(damage);
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}

    //private void CreateImpact(RaycastHit hit)
    //{
    //    //Instantiate Hit effect with rotation from shot direction
    //    GameObject impact = Instantiate(hitFX, hit.point, Quaternion.LookRotation(hit.normal));
    //    Destroy(impact, 0.1f);
    //}
}
