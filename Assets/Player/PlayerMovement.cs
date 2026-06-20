using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    public bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Animator animator;
    private SpriteRenderer sprite;

    public bool movementLocked;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        if (moveInput.x > 0.1f)
            sprite.flipX = false;
        else if (moveInput.x < -0.1f)
            sprite.flipX = true;

        animator.SetBool("IsWalking", true);
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (!movementLocked)
        {
            rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
        }

        if (rb.linearVelocity.x == 0)
        {
            animator.SetBool("IsWalking", false);
        }

        if (rb.linearVelocity.y >= 0)
        {
            animator.SetBool("IsFalling", false);
        }
        else
        {
            if (isGrounded)
            {
                animator.SetBool("IsFalling", false);
            }
            else
            {
                animator.SetBool("IsFalling", true);
            }
        }

    }
}
