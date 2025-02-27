using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{

    protected bool isOn;

    public virtual void turnOn()
    {
        isOn = true;
    }

    public virtual void turnOff()
    {
        isOn = false;
    }

    public bool getIsOn()
    {
        return isOn;
    }

}
