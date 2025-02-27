using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool Pressed;
    public GameObject interactibleObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            transform.parent.GetComponent<SpriteRenderer>().color = Color.green;

            Interactible i = interactibleObject.GetComponent<Interactible>();
            i.turnOn();

            Pressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            transform.parent.GetComponent<SpriteRenderer>().color = Color.red;

            Interactible i = interactibleObject.GetComponent<Interactible>();
            i.turnOff();

            Pressed = false;
        }
    }
}
