using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    AudioSource myAudioSource;

    [SerializeField] AudioSample[] audioSample;

    //Add SFX from Unity Editor
    [System.Serializable]
    private class AudioSample
    {
        public string soundName;
        public AudioClip audioClip;
        public float soundVolume = 0.8f;
    }

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    //Singleton
    private void Awake()
    {
        int musicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (musicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlaySFX(string soundName)
    {
        myAudioSource.PlayOneShot(GetSample(soundName).audioClip, GetSample(soundName).soundVolume);
    }

    public void PlaySFXRandomPitch(string soundName)
    {
        myAudioSource.pitch = Random.Range(0.7f, 1.3f);
        myAudioSource.PlayOneShot(GetSample(soundName).audioClip, GetSample(soundName).soundVolume);
    }

    private AudioSample GetSample(string soundName)
    {
        foreach (AudioSample audioFile in audioSample)
        {
            if (audioFile.soundName == soundName)
            {
                return audioFile;
            }
        }
        return null;

    }

}
