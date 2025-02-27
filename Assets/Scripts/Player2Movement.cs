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

    GameObject FloorTrigger;

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

        // rb.velocity = Vector2.zero ;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity = new Vector2(1 * speed, rb.velocity.y);
            rb.velocity = velocity;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity = new Vector2(-1 * speed, rb.velocity.y);
            rb.velocity = velocity;

        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && OnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, 1 * JumpHeight);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //velocity = Vector2.right;
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
