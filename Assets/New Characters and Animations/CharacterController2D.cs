using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpForce = 1f;
    public Transform groundCheck; // Assign an empty GameObject below the player
    public float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get input
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Move character
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Check if moving
        bool isMoving = moveInput != 0;
        anim.SetBool("isMoving", isMoving);

        // Flip sprite direction
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Set airborne state
        anim.SetBool("isAirborne", !isGrounded);
    }

    void FixedUpdate()
    {
        // Ground check using OverlapCircle to detect ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, LayerMask.GetMask("Default"));
    }
}
