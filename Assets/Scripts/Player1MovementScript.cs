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
    bool Walking;
    bool WasMovingLastFrame;
    public bool MovementEnabled;

    public GameObject SoundObj;
    public GameObject Particles;

    float stepTimer;
    float stepInterval = 0.3f;

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
        Walking = false;

        // rb.velocity = Vector2.zero ;

        if (MovementEnabled)
        {
            if (Input.GetKey(KeyCode.D))
            {
                velocity = new Vector2(1 * speed, rb.velocity.y);
                rb.velocity = velocity;
                Walking = true;


            }
            if (Input.GetKey(KeyCode.A))
            {
                velocity = new Vector2(-1 * speed, rb.velocity.y);
                rb.velocity = velocity;
                Walking=true;

            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (NumberOfJumps != 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 1 * JumpHeight);

                    Instantiate(Particles, transform.position, Quaternion.identity);

                    NumberOfJumps--;


                    GameObject NewSound = Instantiate(SoundObj, transform.position, Quaternion.identity);
                    NewSound.GetComponent<SoundScript>().PlayVampireJumpSoundEffect();

                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {

            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(OnDeath());
            }
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

        GetComponent<SpriteRenderer>().color = Color.red;
        rb.gravityScale = 0;
        MovementEnabled = false;

        GameObject NewSound = Instantiate(SoundObj, transform.position, Quaternion.identity);
        NewSound.GetComponent<SoundScript>().PlayVampireDeathSound();


        yield return new WaitForSecondsRealtime(NewSound.GetComponent<SoundScript>().audioSource.clip.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        yield return null;
    }

}
