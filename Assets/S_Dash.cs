using UnityEngine;

public class S_Dash : CharacterSpecial
{
    public float maxDashSpeed = 20f;
    public float dashDuration = 7f; // time to reach max speed
    public LayerMask stopLayers;

    private Rigidbody2D rb;
    private bool isDashing;
    private float dashTimer;
    private PlayerMovement movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
    }

    public override void UseSpecial()
    {
        dashTimer = 0f; 
        isDashing = true;
        movement.movementLocked = true;
    }


    void FixedUpdate()
    {
        if (!isDashing)
            return;

        dashTimer += Time.fixedDeltaTime;

        float t = Mathf.Clamp01(dashTimer / dashDuration);

        float speed = Mathf.Lerp(0.4f, maxDashSpeed, Mathf.SmoothStep(0.4f, 1f, t));

        float direction = Mathf.Sign(transform.localScale.x);

        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 0.5f, stopLayers);
        if (hit.collider != null)
        {
            StopDash();
        }
    }

    void StopDash()
    {
        isDashing = false;
        movement.movementLocked = false;
        rb.linearVelocity = Vector2.zero;
    }
}
