using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    float horizontalMove = 0f;
    float verticalMove = 0f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {

        if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false; // 오른쪽 방향
        }
        else if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true; // 왼쪽 방향
        }


        rb.velocity = new Vector2(horizontalMove * speed, verticalMove * speed);
    }

}
