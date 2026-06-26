using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            CoinManager.Instance.AddCoin(1);
            Destroy(gameObject);
        }
    }
}
