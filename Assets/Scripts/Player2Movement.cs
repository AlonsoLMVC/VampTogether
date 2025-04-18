using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    public int JumpHeight;
    public bool OnGround;
    public float decelerationRate;
    bool Walking;

    GameObject FloorTrigger;

    public bool MovementEnabled;
    public GameObject SoundObj;

    float stepTimer;
    float stepInterval = 0.25f;
    bool WasMovingLastFrame;

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
        Walking = false;


        // rb.velocity = Vector2.zero ;

        

        if (MovementEnabled)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                velocity = new Vector2(1 * speed, rb.velocity.y);
                rb.velocity = velocity;
                Walking = true;

                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                velocity = new Vector2(-1 * speed, rb.velocity.y);
                rb.velocity = velocity;
                Walking = true;

                GetComponent<SpriteRenderer>().flipX = true;

            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && OnGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, 1 * JumpHeight);

                GameObject NewSound = Instantiate(SoundObj, transform.position, Quaternion.identity);
                NewSound.GetComponent<SoundScript>().PlayHumanJumpSoundEffect();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                //velocity = Vector2.right;

            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(OnDeath());
            }


            if (rb.velocity.magnitude > 0.1f)
            {
                rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, decelerationRate * Time.deltaTime);
            }
            else
            {
                rb.velocity = Vector2.zero; // Stop completely when velocity is very low
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



        if (OnGround && Walking)
        {
            if (!WasMovingLastFrame)
            {
                GameObject NewSound = Instantiate(SoundObj, transform.position, Quaternion.identity);
                NewSound.GetComponent<SoundScript>().PlayFootStep("Grass");
                stepTimer = 0f;
            }
            else
            {

                stepTimer += Time.deltaTime;

                if (stepTimer >= stepInterval)
                {
                    GameObject NewSound = Instantiate(SoundObj, transform.position, Quaternion.identity);
                    NewSound.GetComponent<SoundScript>().PlayFootStep("Grass");
                    stepTimer = 0f;
                }
            }
        }
        else
        {
            stepTimer = 0f;
        }
        WasMovingLastFrame = Walking;
    }


    public IEnumerator OnDeath()
    {
        float fadeDuration = 0.25f;

        StartCoroutine(GameObject.Find("Canvas").GetComponent<CanvasScript>().FadeToBlack(fadeDuration));

        GetComponent<SpriteRenderer>().color = Color.red;
        rb.gravityScale = 0;

        MovementEnabled = false;


        GameObject NewSound = Instantiate(SoundObj, transform.position, Quaternion.identity);
        NewSound.GetComponent<SoundScript>().PlayHumanDeathSound();

        yield return new WaitForSecondsRealtime(NewSound.GetComponent<SoundScript>().audioSource.clip.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        yield return null;
    }

}
