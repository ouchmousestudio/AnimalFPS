using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.PostProcessing;

public class PostEffects : MonoBehaviour
{
    private PostProcessVolume volume;

    private void Start()
    {
        volume = GetComponent<PostProcessVolume>();
    }

    public IEnumerator Glow(float duration, float magnitude)
    {

        float elapsed = 0f;

        while (elapsed < duration)
        {
            if (volume != null)
            {

            }
                elapsed += Time.deltaTime;

            yield return null;
        }
    }
}
