using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{

    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    private Weapon rotateToMouse;

    private GameObject effectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        rotateToMouse = FindObjectOfType<Weapon>();
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnVFX()
    {
        GameObject vfx;

        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            if (rotateToMouse != null)
            {
                vfx.transform.localRotation = rotateToMouse.GetRotation();
            }
        }
        else
        {
            Debug.Log("Firepoint not found");
        }

    }
}
