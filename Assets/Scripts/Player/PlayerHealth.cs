﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float hitPoint = 200f;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas hudCanvas;
    [SerializeField] Canvas bossHP;
    //Drop gun after death
    //[SerializeField] Rigidbody myGun;

    Collider  playerCollider;
    SceneLoader sceneLoader;

    private void Awake()
    {
        hudCanvas.enabled = true;
        gameOverCanvas.enabled = false;

        playerCollider = GetComponent<CapsuleCollider>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            GetComponent<ECM.Components.MouseLook>().lockCursor = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            sceneLoader.LoadMenu();

        }
    }

    //create a public method which reduces hitpoints by damage.
    public void TakeDamage(float damage)
    {
        hitPoint -= damage;
        if (hitPoint <= 0)
        {
            DeathEvent();
        }
    }

    public void DeathEvent()
        {
            //Deactive isAlive to stop weapon being fired.
            GetComponentInChildren<Weapon>().isAlive = false;

            //Dtop gun after death
            //myGun.isKinematic = false;
        
            //Fall over Animation
            GetComponent<Animator>().SetTrigger("death");
            //Display UI
            gameOverCanvas.enabled = true;
            hudCanvas.enabled = false;
            if (bossHP != null)
            {
                bossHP.enabled = false;
            }
        }

    private void FreezeScreen()
    {
        //Make cursor visible to navigate Game over Menu.
        GetComponent<ECM.Components.MouseLook>().lockCursor = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
}
