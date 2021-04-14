using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyTeleport : MonoBehaviour
{
    private bool isDissolving = true;

    private float dissolveAmount = 4.5f;
    [SerializeField] VisualEffect uploadParticles;
    [SerializeField] float dissolveSpeed = 2f;

    [SerializeField] float minClamp = 1f;
    [SerializeField] float maxClamp = 4.5f;

    [SerializeField] float vfxDelayTime = 1f;

    private Renderer myRenderer;
    private MaterialPropertyBlock myPropBlock;

    private void Awake()
    {
        myPropBlock = new MaterialPropertyBlock();
        myRenderer = GetComponentInChildren<Renderer>();

    }

    private void Update()
    {
        if (isDissolving)
        {
            dissolveAmount = Mathf.Clamp(dissolveAmount + dissolveSpeed * Time.deltaTime, minClamp, maxClamp);

            myPropBlock.SetFloat("_CutoffHeight", dissolveAmount);
            myRenderer.SetPropertyBlock(myPropBlock);
        }
        else
        {
            dissolveAmount = Mathf.Clamp(dissolveAmount - dissolveSpeed * Time.deltaTime, minClamp, maxClamp);
            //Shader.SetGlobalFloat(propertyId, dissolveAmount);

            myPropBlock.SetFloat("_CutoffHeight", dissolveAmount);
            myRenderer.SetPropertyBlock(myPropBlock);
        }
    }

    public void DissolveIn()
    {
        isDissolving = true;
    }

    public void DissolveOut()
    {
        isDissolving = false;
        //Add Basic timer to the VFX, to time with the shader dissolve String Reference
        Invoke("UploadVFX", vfxDelayTime);
    }

    private void UploadVFX()
    {
        if (!uploadParticles) { return; }
        uploadParticles.Play();
    }
}
