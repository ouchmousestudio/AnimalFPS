using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayerAK : MonoBehaviour
{

    [SerializeField] WwiseEvent[] wwiseEvent;

    [System.Serializable]
    private class WwiseEvent
    {
        public string soundName;
        public AK.Wwise.Event MyEvent;
    }

    public void PlaySFX(string soundName, GameObject gameObj)
    {
        GetEvent(soundName).MyEvent.Post(gameObj);
    }

    private WwiseEvent GetEvent(string soundName)
    {
        foreach (WwiseEvent sample in wwiseEvent)
        {
            if (sample.soundName == soundName)
            {
                return sample;
            }
        }
        return null;
    }
}
