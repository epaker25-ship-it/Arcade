using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            col.collider.GetComponent<PlayerHealth>().TakeDamage(1);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
