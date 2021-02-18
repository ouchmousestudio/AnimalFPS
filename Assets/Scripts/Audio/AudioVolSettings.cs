using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolSettings : MonoBehaviour
{
    public AK.Wwise.RTPC MusicVolume;
    [Range(0f, 100f)]
    [SerializeField] float musicVol = 40f;


    // Update is called once per frame
    void Update()
    {
        MusicVolume.SetGlobalValue(musicVol);
    }
}
