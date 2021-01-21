using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{

    public enum musicStates
    {
        Normal = 0,
        Calm = 1,
        Tense = 2,
    }

    AudioSource myAudioSource;

    [SerializeField] private AudioClip musicStart;
    [SerializeField] private AudioMixerSnapshot[] tracks = new AudioMixerSnapshot[3];
    private int selectionIndex;
    [SerializeField] float transitionSpeed = 0.5f;
    [SerializeField] private musicStates currentState;


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

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();

        myAudioSource.PlayOneShot(musicStart);
        myAudioSource.PlayScheduled(AudioSettings.dspTime + musicStart.length);
    }

    private void Update()
    {
        //if (selectionIndex != (int)currentState)
        //{
        //    selectionIndex = (int)currentState;
        //    tracks[selectionIndex].TransitionTo(transitionSpeed);
        //}
    }

    public void ChangeMusic(musicStates state)
    {
        if (selectionIndex != (int)state)
        {
            selectionIndex = (int)state;
            tracks[selectionIndex].TransitionTo(transitionSpeed);
        }
    }




    public void SetVolume(float volume)
    {
        myAudioSource.volume = volume;
    }


}
