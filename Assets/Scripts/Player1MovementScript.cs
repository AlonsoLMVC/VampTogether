using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public bool MovementEnabled;

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        FloorTrigger = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        OnGround = FloorTrigger.GetComponent<FloorTriggerScript>().OnGround;
        anim.SetBool("isAirborne", !OnGround);

        Vector2 velocity = Vector2.zero;

        // rb.velocity = Vector2.zero ;

        

        if (MovementEnabled)
        {
            if (Input.GetKey(KeyCode.D))
            {
                velocity = new Vector2(1 * speed, rb.velocity.y);
                rb.velocity = velocity;

                GetComponent<SpriteRenderer>().flipX = false;


            }
            if (Input.GetKey(KeyCode.A))
            {
                velocity = new Vector2(-1 * speed, rb.velocity.y);
                rb.velocity = velocity;

                GetComponent<SpriteRenderer>().flipX = true;

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
        }







        if (velocity != Vector2.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
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



    public IEnumerator OnDeath()
    {
        float fadeDuration = 0.25f;

        StartCoroutine(GameObject.Find("Canvas").GetComponent<CanvasScript>().FadeToBlack(fadeDuration));

        GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSecondsRealtime(fadeDuration);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        yield return null;
    }

}
