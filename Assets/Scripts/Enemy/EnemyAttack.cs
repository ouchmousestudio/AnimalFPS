using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private PlayerHealth target;
    [SerializeField] float damage = 40f;
    private CameraShake cameraShake;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        cameraShake = FindObjectOfType<CameraShake>();
    }

    public void AttackHitEvent()
    {
        if (!target) return;
        target.GetComponent<PlayerHealth>().TakeDamage(damage);

        StartCoroutine(cameraShake.Shake(0.15f, 0.2f));
    }
}
