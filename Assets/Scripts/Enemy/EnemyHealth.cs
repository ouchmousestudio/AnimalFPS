using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoint = 100f;
    private float hitPointMax;
    [SerializeField] float deathTime = 1.5f;
    [SerializeField] float timeuntilVFX = 1f;
    [SerializeField] ParticleSystem deathFX;
    [SerializeField] Slider enemyHealth;
    [SerializeField] string sfxName = "";

    private SFXPlayer sFXPlayer;

    private Animator myAnimator;

    private bool isDead = false;

    private void Start()
    {
        hitPointMax = hitPoint;
        myAnimator = GetComponent<Animator>();
        sFXPlayer = FindObjectOfType<SFXPlayer>();
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
        Destroy(gameObject, deathTime);
        if (isDead == false)
        {
            isDead = true;
            myAnimator.SetBool("isWalking", false);
            myAnimator.SetBool("isRunning", false);
            myAnimator.SetBool("isDead", true);
            if (sfxName != "")
            {
                sFXPlayer.PlaySFX(sfxName);
            }
            StartCoroutine(SpawnVFX());
        }
    }

    IEnumerator SpawnVFX()
    {
        yield return new WaitForSecondsRealtime(timeuntilVFX);
        Instantiate(deathFX, transform.position, Quaternion.identity);
    }
}
