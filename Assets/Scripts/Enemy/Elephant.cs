using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elephant : MonoBehaviour
{
    [SerializeField] GameObject bossHealthUI;
    [SerializeField] AudioSource bossTheme;
    [SerializeField] EnemyHealth elephantHealth;
    [SerializeField] GameObject portal;

    Transform target;
    //How far away from target
    private float distanceToTarget = Mathf.Infinity;

    private float chaseRange = 50f;
    private bool hasStarted = false;


    private void Start()
    {
        elephantHealth = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget < chaseRange)
        {

            if (hasStarted == false)
            {
                hasStarted = true;
                bossHealthUI.SetActive(true);
                bossTheme.Play();
            }
        }
        else { return; }
    }


    private void OnDisable()
    {
        if (bossHealthUI != null) { bossHealthUI.SetActive(false); }
        if (bossTheme != null) { bossTheme.Stop(); }
        if (portal != null) { portal.SetActive(true); }
    }

}
