using UnityEngine;

public class EnemyWalker : MonoBehaviour
{
    public float speed = 2f;
    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;

    private Rigidbody2D rb;
    private bool movingRight = true;

    public Transform feetCheck;
    public float feetRadius = 0.2f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // move
        rb.linearVelocity = new Vector2((movingRight ? 1 : -1) * speed, rb.linearVelocity.y);

        bool isGrounded = Physics2D.OverlapCircle(feetCheck.position, feetRadius, groundLayer);

        // only flip when ON the ground
        if (!isGrounded)
            return;

        bool wallHit = Physics2D.OverlapCircle(wallCheck.position, 0.1f, groundLayer);
        bool groundAhead = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        bool enemyAhead = Physics2D.OverlapCircle(wallCheck.position, 0.1f, enemyLayer);

        if (wallHit || enemyAhead || !groundAhead)
            Flip();

    }

    void Flip()
    {
        movingRight = !movingRight;
        transform.localScale = new Vector3(movingRight ? 1 : -1, 1, 1);
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
