using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int pickupAmount = 10;
    [SerializeField] GameObject pickupMesh;


    private bool hasPickedUp = false;
    private ParticleSystem ps;
    private PlayerHealth playerHealth;

    private void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!hasPickedUp)
            {
                hasPickedUp = true;
                FindObjectOfType<SFXPlayer>().PlaySFX("HealthPickup");
                playerHealth.IncreaseHealth(pickupAmount);
                Destroy(pickupMesh);
                ps.Stop();
                Destroy(gameObject, 2f);
            }

        }
    }
}
