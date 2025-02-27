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

        Ray2D ray;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject != transform.parent.gameObject)
            {
                OnGround = true;
            }
            Debug.Log(hit.collider.gameObject);
        }
        else
        {
            OnGround = false;

        }


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
