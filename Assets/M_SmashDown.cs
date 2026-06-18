using UnityEngine;

public class M_SmashDown : CharacterSpecial
{
    public float smashForce = -20f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void UseSpecial()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, smashForce);
        Debug.Log("M used Smash Down!");
    }
}
