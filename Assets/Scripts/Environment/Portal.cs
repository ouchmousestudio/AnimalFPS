using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    [SerializeField] Material portalMat;
    [SerializeField] string level;
    private bool isDissolving = false;

    private float dissolveAmount = 10f;
    [SerializeField] float dissolveSpeed = 3f;

    private void Update()
    {
        if (isDissolving)
        {
            if (dissolveAmount > 1f)
            {
                dissolveAmount = dissolveAmount - dissolveSpeed * Time.deltaTime;
                portalMat.SetFloat("_DAmount", dissolveAmount);
            }
        }
    }

    private void OnEnable()
    {
        isDissolving = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Todo: Replace with enum or string.
        FindObjectOfType<SceneLoader>().LoadLevel(level);
    }

}
