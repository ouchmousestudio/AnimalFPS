using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{

    [SerializeField] Weapon myWeapon;
    [SerializeField] ParticleSystem hitFX;
    [SerializeField] float enemyDamage;

    private ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    private void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject target)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(part, target, collisionEvents);

        int numCollisionEvents = part.GetCollisionEvents(target, collisionEvents);

        for (int i = 0; i < collisionEvents.Count; i++)
        {
            EmitHitFX(collisionEvents[i]);
        }


        //Todo: Add Hit effect for visual
        if (target.GetComponent<EnemyHealth>())
        {
            EnemyHealth targetHealth = target.GetComponent<EnemyHealth>();
            targetHealth.TakeDamage(myWeapon.damage);
        }
        else if (target.GetComponent<PlayerHealth>())
        {
            PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(enemyDamage);
            part.Clear();
        }

        
    }

    private void EmitHitFX(ParticleCollisionEvent particleCollisionEvent)
    {
        if (hitFX != null)
        {
            Instantiate(hitFX, particleCollisionEvent.intersection, Quaternion.LookRotation(particleCollisionEvent.normal));
        }
        else
        {
            Debug.Log("No HitFX found");
        }
    }

}
