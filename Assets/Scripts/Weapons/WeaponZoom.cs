using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;

    [SerializeField] int normalFOV = 60;
    [SerializeField] int zoomFOV = 40;
    [SerializeField] float smoothingAmount = 5f;

    [SerializeField] float normalSensitivity = 2f;
    [SerializeField] float zoomSensitivity = 1.2f;

    [SerializeField] Animator weaponAnimation;

    bool isZoomed = false;

    private void OnDisable()
    {
        ZoomOut();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            isZoomed = true;
            
        }
        else
        {
            isZoomed = false;
            
        }

        if (isZoomed)
        {
            ZoomIn();

        }
        else
        {
            ZoomOut();
        }

    }

    private void ZoomIn()
    {
        weaponAnimation.SetBool("isZoomed", isZoomed);
        fpsCamera.fieldOfView = Mathf.Lerp(fpsCamera.fieldOfView, zoomFOV, Time.deltaTime * smoothingAmount);
    }

    private void ZoomOut()
    {
        weaponAnimation.SetBool("isZoomed", isZoomed);
        fpsCamera.fieldOfView = Mathf.Lerp(fpsCamera.fieldOfView, normalFOV, Time.deltaTime * smoothingAmount);
    }

}
