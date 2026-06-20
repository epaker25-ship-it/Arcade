using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float flashTime = 0.15f;

    private Color originalColor;

    void Awake()
    {
        if (sprite == null)
            sprite = GetComponentInChildren<SpriteRenderer>();

        originalColor = sprite.color;
    }

    public void Flash(Color flashColor)
    {
        StopAllCoroutines();
        StartCoroutine(FlashRoutine(flashColor));
    }

    private System.Collections.IEnumerator FlashRoutine(Color flashColor)
    {
        sprite.color = flashColor;
        yield return new WaitForSeconds(flashTime);
        sprite.color = originalColor;
    }
}