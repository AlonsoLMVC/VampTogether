using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardScript : MonoBehaviour
{
    public string AffectsPlayer;
    public bool KillsBothPlayers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null)

            Debug.Log(collider);
        {
            if (collider.gameObject.tag == AffectsPlayer || KillsBothPlayers)
            {
                if(collider.gameObject.GetComponent<Player2Movement>() != null)
                {
                    StartCoroutine(collider.gameObject.GetComponent<Player2Movement>().OnDeath());

                }
                else if (collider.gameObject.GetComponent<Player1MovementScript>() != null)
                {
                    StartCoroutine(collider.gameObject.GetComponent<Player1MovementScript>().OnDeath());

                }

            }
           

        }
    }
}
