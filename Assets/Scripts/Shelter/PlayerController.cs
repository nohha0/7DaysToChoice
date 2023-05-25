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
    private bool isMoving = false;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
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

        
        // 방향키 입력 여부에 따라 애니메이션 상태 변경
        if (horizontalMove != 0 || verticalMove != 0)
        {
            isMoving = true;
            if (horizontalMove > 0)
            {
                spriteRenderer.flipX = false; // 오른쪽 방향

            }
            else if (horizontalMove < 0)
            {
                spriteRenderer.flipX = true; // 왼쪽 방향
            }
        }
        else
        {
            isMoving = false;
        }
        animator.SetBool("run", isMoving);



        rb.velocity = new Vector2(horizontalMove * speed, verticalMove * speed);
    }

}
