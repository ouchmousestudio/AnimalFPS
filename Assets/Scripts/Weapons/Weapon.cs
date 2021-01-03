using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
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

    private float lastShot = 0f;
    public bool isAlive = true;

    //Raycast variables for Aim()
    private Ray rayMouse;
    private Vector3 direction;
    private Quaternion rotation;


    private void OnEnable()
    {
        //Display Ammo count in UI
        DisplayAmmo();
    }

    private void Update()
    {
        //Aim();
        if (Input.GetButton("Fire1") && isAlive)
        {
            Shoot();
        }

        //Todo : Temporary reload for debug
        if (Input.GetKeyDown(KeyCode.R))
        {
            ammoSlot.Reload(ammoType);
            DisplayAmmo();
        }
    }


    private void Aim()
    {
        if (PlayerCamera != null)
        {
            RaycastHit hit;
            var mousePos = Input.mousePosition;
            rayMouse = PlayerCamera.ScreenPointToRay(mousePos);
            if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, maxRange))
            {
                RotateToMouseDirection(gameObject, hit.point);
            }
            else
            {
                var pos = rayMouse.GetPoint(maxRange);
                RotateToMouseDirection(gameObject, hit.point);
            }
        }
        else { Debug.Log("No Camera found"); }
    }

    private void RotateToMouseDirection(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }

    public Quaternion GetRotation()
    {
        return rotation;
    }

    private void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo(ammoType) >= 1)
        {
            if (Time.time > fireRate + lastShot)
            {
                PlayMuzzleFlash();
                laserBeam.Emit(1);

                ammoSlot.ReduceCurrentAmmo(ammoType);

                DisplayAmmo();
                GetComponent<Animator>().SetTrigger("isFired");
                lastShot = Time.time;
            }
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void DisplayAmmo()
    {
        ammoSlider.value = ammoSlot.GetCurrentAmmo(ammoType) / 30f;
    }
}