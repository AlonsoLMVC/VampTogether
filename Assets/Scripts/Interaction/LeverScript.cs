using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject interactibleObject; // The object controlled by the lever
    public float activationAngle = 30f; // Angle to turn on
    public float deactivationAngle = -30f; // Angle to turn off

    private bool isOn = false; // Tracks the state

    void Update()
    {
        // Get the lever's rotation in degrees
        float leverAngle = transform.eulerAngles.z;
        if (leverAngle > 180) leverAngle -= 360; // Normalize angle to -180 to 180

        // Toggle on when reaching activation angle
        if (!isOn && leverAngle >= activationAngle)
        {
            isOn = true;
            ToggleInteractible(true);
        }
        // Toggle off when reaching deactivation angle
        else if (isOn && leverAngle <= deactivationAngle)
        {
            isOn = false;
            ToggleInteractible(false);
        }
    }

    void ToggleInteractible(bool state)
    {
        
        if (interactibleObject != null)
        {
            Interactible i = interactibleObject.GetComponent<Interactible>();
            if (i != null)
            {
                if (state) i.turnOn();
                else i.turnOff();
            }
        }
    }
}
