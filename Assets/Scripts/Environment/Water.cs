using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<SFXPlayerAK>().PlaySFX("WaterSplash", gameObject);
        FindObjectOfType<PlayerHealth>().DeathEvent();
    }
}