using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float hitPoint = 100f;
    [SerializeField] float deathTime = 1.5f;
    [SerializeField] ParticleSystem deathFX;

    Animator myAnimator;

    bool hasDied = false;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    //create a public method which reduces hitpoints by damage.

    public void TakeDamage(float damage)
    {
        hitPoint -= damage;
        if (hitPoint <= 0)
        {
            Destroy(gameObject, deathTime);
            if (hasDied == false)
            {
                hasDied = true;
                myAnimator.SetBool("isDead", true);
                deathFX.Play();
                Instantiate(deathFX, transform.position, Quaternion.identity);
            } 

            
        }

    }
}
