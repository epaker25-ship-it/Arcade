using UnityEngine;

public class EnemyWalker : MonoBehaviour
{
    public float speed = 2f;
    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool movingRight = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2((movingRight ? 1 : -1) * speed, rb.linearVelocity.y);

        bool wallHit = Physics2D.OverlapCircle(wallCheck.position, 0.1f, groundLayer);

        bool groundAhead = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if (wallHit || !groundAhead)
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
