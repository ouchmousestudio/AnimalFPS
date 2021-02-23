using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostEffects : MonoBehaviour
{
    private Volume volume;
    private float glitchAmount = 1f;
    private float bloomAmount = 10f;
    private ChromaticAberration chromaticAberration;
    private FilmGrain filmGrain;
    private Bloom bloom;

    private float originalBloomAmount; 

    private void Awake()
    {
        volume = GetComponent<Volume>();

        volume.profile.TryGet<ChromaticAberration>(out chromaticAberration);
        volume.profile.TryGet<FilmGrain>(out filmGrain);
        volume.profile.TryGet<Bloom>(out bloom);
    }
    private void Start()
    {
        originalBloomAmount = bloom.intensity.value;
    }

    public IEnumerator Glitch()
    {
        float elapsed = 0f;

        glitchAmount = 1f;

        while (elapsed < 2f)
        {
            if (volume != null)
            {
                glitchAmount = Mathf.Clamp(glitchAmount - 1f * Time.deltaTime, 0f, 1f);
                filmGrain.intensity.value = glitchAmount;
                chromaticAberration.intensity.value = glitchAmount;
            }

                elapsed += Time.deltaTime;

            yield return null;
        }
        chromaticAberration.intensity.value = 0;
        filmGrain.intensity.value = 0f;
    }


    public IEnumerator Glow()
    {
        float elapsed = 0f;

        bloomAmount = 30f;

        while (elapsed < 1.5f)
        {
            if (volume != null)
            {
                bloomAmount = Mathf.Clamp(bloomAmount - 30f * Time.deltaTime, originalBloomAmount, 30f);
                bloom.intensity.value = bloomAmount;
            }

            elapsed += Time.deltaTime;

            yield return null;
        }
        bloom.intensity.value = originalBloomAmount;

    }
}
