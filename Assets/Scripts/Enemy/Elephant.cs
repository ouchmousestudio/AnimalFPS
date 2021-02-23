using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elephant : MonoBehaviour
{
    [Header("Audio")]
    public AK.Wwise.Event trumpet;
    public AK.Wwise.Event stomp;
    public AK.Wwise.Event fall;

    public void PlayTrumpet()
    {
        trumpet.Post(gameObject);
    }

    public void PlayStomp()
    {
        stomp.Post(gameObject);
    }

    public void PlayFall()
    {
        fall.Post(gameObject);
    }

}
