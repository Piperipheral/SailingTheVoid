using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeSprite : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        float randomScale = Random.Range(1f, 2f);
        transform.localScale = new Vector3(randomScale, randomScale, 1);
        spriteRenderer.flipX = Random.Range(0, 10) > 5;
    }
}
