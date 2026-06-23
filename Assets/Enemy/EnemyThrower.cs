using UnityEngine;

public class EnemyThrower : MonoBehaviour
{
    public Transform throwPoint;
    public GameObject projectilePrefab;
    public float throwCooldown = 2f;
    public float throwForce = 8f;
    public float upwardForce = 4f;
    public float detectionRange = 8f;

    private float cooldownTimer = 0f;
    private bool hasProjectileOut = false;

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= detectionRange && cooldownTimer <= 0f && !hasProjectileOut)
        {
            ThrowProjectile(player.transform);
        }
    }

    void ThrowProjectile(Transform target)
    {
        cooldownTimer = throwCooldown;

        GameObject proj = Instantiate(projectilePrefab, throwPoint.position, Quaternion.identity);
        hasProjectileOut = true;

        Destroy(proj, 5f);
        Invoke(nameof(ResetProjectileFlag), 5f);

        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();

        Vector2 dir = (target.position - throwPoint.position).normalized;

        Vector2 force = new Vector2(dir.x * throwForce, upwardForce);

        rb.AddForce(force, ForceMode2D.Impulse);
    }

    void ResetProjectileFlag()
    {
        hasProjectileOut = false;
    }
}
