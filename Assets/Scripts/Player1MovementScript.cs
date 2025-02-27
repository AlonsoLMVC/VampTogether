using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1MovementScript : MonoBehaviour
{

    Rigidbody2D rb;
    public int speed;
    public int JumpHeight;
    public bool OnGround;
    public float decelerationRate;
    GameObject FloorTrigger;
    public int NumberOfJumps;
    public int MaxNumberOfJumps;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        FloorTrigger = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        OnGround = FloorTrigger.GetComponent<FloorTriggerScript>().OnGround;

        Vector2 velocity = Vector2.zero;

       // rb.velocity = Vector2.zero ;

        if (Input.GetKey(KeyCode.D))
        {
            velocity = new Vector2(1 * speed, rb.velocity.y);
            rb.velocity = velocity;

        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity = new Vector2(-1 *speed, rb.velocity.y);
            rb.velocity = velocity;

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (NumberOfJumps != 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 1 * JumpHeight);
                NumberOfJumps--;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
           
        }
       



        if (rb.velocity.magnitude > 0.1f)
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, decelerationRate * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector2.zero; // Stop completely when velocity is very low
        }

        if (OnGround)
        {
            NumberOfJumps = MaxNumberOfJumps;
        }


    }

    
}
