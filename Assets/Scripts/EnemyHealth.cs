using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float hitPoint = 100f;

    //create a public method which reduces hitpoints by damage.

    public void TakeDamage(float damage)
    {
        hitPoint -= damage;
        if (hitPoint <= 0)
        {
            Destroy(gameObject);
        }

    }
}
