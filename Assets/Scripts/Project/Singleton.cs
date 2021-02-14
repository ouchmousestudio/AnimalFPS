using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    //Singleton
    private void Awake()
    {
        int singleton = FindObjectsOfType<Singleton>().Length;
        if (singleton > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
