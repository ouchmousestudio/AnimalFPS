using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoint = 100f;
    float hitPointMax;
    [SerializeField] float deathTime = 1.5f;
    [SerializeField] float timeuntilVFX = 1f;
    [SerializeField] ParticleSystem deathFX;
    [SerializeField] Slider enemyHealth;

    Animator myAnimator;

    bool isDead = false;

    private void Start()
    {
        hitPointMax = hitPoint;
        myAnimator = GetComponent<Animator>();
    }


    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        hitPoint -= damage;

        //Update HealthUI
        if (enemyHealth != null) { enemyHealth.value = hitPoint / hitPointMax; }

        if (hitPoint <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        //Remove HealthUI
        if (enemyHealth != null) { enemyHealth.gameObject.SetActive(false); }

        Destroy(gameObject, deathTime);
        if (isDead == false)
        {
            isDead = true;
            myAnimator.SetBool("isWalking", false);
            myAnimator.SetBool("isRunning", false);
            myAnimator.SetBool("isDead", true);
            StartCoroutine(SpawnVFX());
        }
    }

    IEnumerator SpawnVFX()
    {
        yield return new WaitForSecondsRealtime(timeuntilVFX);
        Instantiate(deathFX, transform.position, Quaternion.identity);
    }
}
