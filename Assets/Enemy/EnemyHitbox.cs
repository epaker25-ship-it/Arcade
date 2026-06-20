using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    private EnemyWalker enemy;

    void Awake()
    {
        enemy = GetComponentInParent<EnemyWalker>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 10f);

            enemy.Kill();
        }
    }
}
