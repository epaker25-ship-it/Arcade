using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFollow : MonoBehaviour
{
    public Transform otherPlayer;
    public float maxDistance = 8f;       
    public float teleportDistance = 20f; 
    public float followSpeed = 6f;

    private Rigidbody2D rb;
    private PlayerMovement movement;
    private PlayerInput input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
        input = GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {
        if (input.enabled)
            return;

        float dist = Vector2.Distance(transform.position, otherPlayer.position);

        if (dist > teleportDistance)
        {
            transform.position = otherPlayer.position + new Vector3(-1f, 0, 0);
            rb.linearVelocity = Vector2.zero;
            return;
        }

        if (dist > maxDistance)
        {
            movement.movementLocked = true;

            Vector2 dir = (otherPlayer.position - transform.position).normalized;
            rb.linearVelocity = new Vector2(dir.x * followSpeed, rb.linearVelocity.y);
        }
        else
        {
            movement.movementLocked = false;
        }
    }
}
