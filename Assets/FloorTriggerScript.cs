using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTriggerScript : MonoBehaviour
{

    public bool OnGround;

    // Start is called before the first frame update
    void Start()
    {
        OnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject != transform.parent.gameObject)
            {
                Debug.Log(collision.gameObject.name);
                    OnGround = true;
                Debug.Log("touch ground");
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject != transform.parent.gameObject)
            {

                OnGround = false;
                Debug.Log("left ground");
            }


        }
    }
}
