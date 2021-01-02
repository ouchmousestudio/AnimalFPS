using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{

    [SerializeField] Weapon myWeapon;

    private void OnParticleCollision(GameObject target)
    {
        //Todo: Add Hit effect for visual
        if (target.GetComponent<EnemyHealth>() == null) return;
        EnemyHealth targetHealth = target.GetComponent<EnemyHealth>();
        targetHealth.TakeDamage(myWeapon.damage);


    }

}
