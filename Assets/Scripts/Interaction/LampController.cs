using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : Interactible
{
    public GameObject lightSource; // The object representing the lamp's light

    public override void turnOn()
    {
        if (lightSource != null)
        {
            lightSource.SetActive(false);
        }
    }

    public override void turnOff()
    {
        if (lightSource != null)
        {
            lightSource.SetActive(true);
        }
    }
}
