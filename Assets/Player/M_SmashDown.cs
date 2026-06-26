using UnityEngine;

public class M_SmashDown : CharacterSpecial
{
    public float smashForce = -20f;
    private Rigidbody2D rb;
    private PlayerMovement movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
    }

    public override void UseSpecial()
    {
        if (!CoinManager.Instance.CanUseSpecial())
            return; 

        if (movement.isGrounded)
            return;

        CoinManager.Instance.SpendCoins();

        GetComponent<FlashEffect>().Flash(new Color(2f, 0f, 0f, 1f));

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, smashForce);
        Debug.Log("M used Smash Down!");
    }

}
