using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float hitPoint = 200f;
    [SerializeField] Canvas gameOverCanvas;
    //Drop gun after death
    //[SerializeField] Rigidbody myGun;

    private void Awake()
    {
        gameOverCanvas.enabled = false;

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

    private void DeathEvent()
    {
        //Deactive isAlive to stop weapon being fired.
        GetComponentInChildren<Weapon>().isAlive = false;

        //Dtop gun after death
        //myGun.isKinematic = false;
        
        //Fall over Animation
        GetComponent<Animator>().SetTrigger("death");
        //Display UI
        gameOverCanvas.enabled = true;
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
