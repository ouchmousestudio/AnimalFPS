using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISounds : MonoBehaviour
{
    public AK.Wwise.Event mouseOverBeep;
    public AK.Wwise.Event selectBeep;

    public void MouseOverBeep()
    {
        mouseOverBeep.Post(gameObject);
    }

    public void SelectBeep()
    {
        selectBeep.Post(gameObject);
    }
}
