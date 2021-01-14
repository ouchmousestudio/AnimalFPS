using System;
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

    private CameraShake cameraShake;

    private void Awake()
    {
        hudCanvas.enabled = true;
        gameOverCanvas.enabled = false;

        playerCollider = GetComponent<CapsuleCollider>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        cameraShake = FindObjectOfType<CameraShake>();

        //Make cursor invisible when restarting.
        GetComponent<ECM.Components.MouseLook>().verticalSensitivity = 2;
        GetComponent<ECM.Components.MouseLook>().lateralSensitivity = 2;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
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
        StartCoroutine(cameraShake.Shake(0.15f, 0.2f));
        hitPoint -= damage;
        if (hitPoint <= 0)
        {
            DeathEvent();
        }
    }

    //For Health Pickups
    public void IncreaseHealth(float health)
    {
        //Todo: Add Post FX
        
        if (hitPoint + health >= 200f)
        {
            hitPoint = 200f;
        }
        else
        {
            hitPoint += health;
        }
    }

    public void DeathEvent()
        {
            //Deactive isAlive to stop weapon being fired.
            GetComponentInChildren<Weapon>().isAlive = false;

            //Drop gun after death
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

        GetComponent<ECM.Components.MouseLook>().verticalSensitivity = 0;
        GetComponent<ECM.Components.MouseLook>().lateralSensitivity = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
}
