using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 2;
    private int hp;

    void Start()
    {
        hp = maxHP;
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;

        if (hp <= 0)
        {
            GameManager.Instance.PlayerDied();
        }
    }
}
