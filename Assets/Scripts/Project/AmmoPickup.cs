using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    [SerializeField] AmmoType ammoType;
    [SerializeField] int pickupAmount = 10;
    [SerializeField] GameObject pickupMesh;

    private PostEffects postEffects;

    private bool hasPickedUp = false;
    private ParticleSystem ps;

    private void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        postEffects = FindObjectOfType<PostEffects>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(!hasPickedUp)
            {
                hasPickedUp = true;
                FindObjectOfType<SFXPlayer>().PlaySFX("AmmoPickup");
                FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, pickupAmount);
                //StartCoroutine(postEffects.Glow(2f, 10f));
                Destroy(pickupMesh);
                ps.Stop();
                Destroy(gameObject, 2f);
            }

        }
    }
}
