using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private SFXPlayer sFXPlayer;

    private void Start()
    {
        sFXPlayer = FindObjectOfType<SFXPlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        sFXPlayer.PlaySFX("waterSplash");
        FindObjectOfType<PlayerHealth>().DeathEvent(); 
    }
}
