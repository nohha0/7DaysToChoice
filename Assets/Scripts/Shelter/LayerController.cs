using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    private Collider2D collider;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (collider.bounds.min.y > -4.47f)
        {
            spriteRenderer.sortingOrder = 1;
        }
        else
        {
            spriteRenderer.sortingOrder = 3;
        }
    }
}