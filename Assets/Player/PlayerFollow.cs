using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform otherPlayer;
    public float maxDistance = 8f;
    public float followSpeed = 5f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float dist = Vector2.Distance(transform.position, otherPlayer.position);

        if (dist > maxDistance)
        {
            Vector2 dir = (otherPlayer.position - transform.position).normalized;
            rb.linearVelocity = new Vector2(dir.x * followSpeed, rb.linearVelocity.y);
        }
    }
}
