using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera PlayerCamera;
    [SerializeField] float maxRange = 100f;
    [Tooltip("Fire rate in seconds")]
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem laserBeam;
    [SerializeField] GameObject hitFX;
    public float damage = 30f;
    [SerializeField] int numberOfShots = 1;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;

    private float lastShot = 0f;
    public bool isAlive = true;

    private void OnEnable()
    {
        //Display Ammo count in UI
        ammoSlot.UpdateAmmoUI(ammoType);
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && isAlive)
        {
            Shoot();
        }

        //Todo : Temporary reload for debug
        if (Input.GetKeyDown(KeyCode.R))
        {
            ammoSlot.Reload(ammoType);
        }
    }

    private void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo(ammoType) >= 1)
        {
            if (Time.time > fireRate + lastShot)
            {
                PlayMuzzleFlash();

                //Play SFX Depending on ammoType
                switch (ammoType)
                {
                    case AmmoType.Pistol:
                    {
                            FindObjectOfType<SFXPlayerAK>().PlaySFX("FireGun", gameObject);
                            break;
                        }
                    case AmmoType.Shotgun:
                    {
                            FindObjectOfType<SFXPlayerAK>().PlaySFX("FireShotgun", gameObject);
                            break;
                        }
                    default:
                        FindObjectOfType<SFXPlayerAK>().PlaySFX("FireGun", gameObject);
                        break;
                }
                //Fire Particle system
                laserBeam.Emit(numberOfShots);

                ammoSlot.ReduceCurrentAmmo(ammoType);

                GetComponent<Animator>().SetTrigger("isFired");
                lastShot = Time.time;
            }
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
}