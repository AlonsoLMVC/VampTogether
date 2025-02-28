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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            if (Input.GetKey(KeyCode.RightArrow))
            {
                velocity = new Vector2(1 * speed, rb.velocity.y);
                rb.velocity = velocity;
                Walking = true;

            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                velocity = new Vector2(-1 * speed, rb.velocity.y);
                rb.velocity = velocity;
                Walking = true;

            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && OnGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, 1 * JumpHeight);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                //velocity = Vector2.right;

                GameObject NewSound = Instantiate(SoundObj, transform.position, Quaternion.identity);
                NewSound.GetComponent<SoundScript>().PlayFootStep("Grass");
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

        GetComponent<SpriteRenderer>().enabled = false;


        yield return new WaitForSecondsRealtime(fadeDuration);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        yield return null;
    }

}
