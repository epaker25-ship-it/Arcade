using UnityEngine;

public class S_Dash : CharacterSpecial
{
    public float maxDashSpeed = 20f;
    public float dashDuration = 7f;
    private Collider2D myCollider;
    public LayerMask stopLayers;

    private Rigidbody2D rb;
    private bool isDashing;
    private float dashTimer;
    private PlayerMovement movement;
    public Transform dashCheckPoint;

    public Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
        myCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    public override void UseSpecial()
    {
        movement.movementLocked = true;

        isDashing = true;
        dashTimer = 0f;

        IgnoreOtherPlayers(true);
        animator.SetBool("IsDashing", true);

        Debug.Log("S used Dash!");
    }

    void IgnoreOtherPlayers(bool ignore)
    {
        Collider2D[] myCols = GetComponentsInChildren<Collider2D>();
        Collider2D[] allCols = FindObjectsOfType<Collider2D>();

        foreach (var mine in myCols)
        {
            foreach (var other in allCols)
            {
                if (other.gameObject != gameObject &&
                    other.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    Physics2D.IgnoreCollision(mine, other, ignore);
                }
            }
        }
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

        RaycastHit2D hit = Physics2D.Raycast(
            dashCheckPoint.position,
            new Vector2(direction, 0),
            0.5f,
            stopLayers
        );
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

        IgnoreOtherPlayers(false);
        animator.SetBool("IsDashing", false);
    }

}
