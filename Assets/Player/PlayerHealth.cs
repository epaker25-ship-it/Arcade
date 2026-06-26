using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 2;
    private int hp;

    private SpriteRenderer sprite;
    private bool isInvincible = false;

    void Awake()
    {
        hp = maxHP;
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void TakeDamage(int amount)
    {
        if (isInvincible)
            return;

        hp -= amount;

        FlashRed();
        StartInvincibility();

        if (hp <= 0)
        {
            GameManager.Instance.PlayerDied();
        }
    }

    void FlashRed()
    {
        sprite.color = Color.red;
        Invoke(nameof(ResetColor), 0.15f);
    }

    void ResetColor()
    {
        sprite.color = Color.white;
    }

    void StartInvincibility()
    {
        isInvincible = true;
        Invoke(nameof(EndInvincibility), 0.5f);
    }

    void EndInvincibility()
    {
        isInvincible = false;
    }
}
