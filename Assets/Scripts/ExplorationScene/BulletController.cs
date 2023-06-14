using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public int score = 0;
    public int pass = 0;
    Battle battle;
    private bool isColliding = false;

    private void Start()
    {
        battle = GameObject.Find("Battle").GetComponent<Battle>();
    }

    private void FixedUpdate()
    {
        // 이동 처리
        transform.Translate(new Vector3(speed, 0, 0));
    }

    private void Update()
    {
        if (isColliding && Input.GetKeyDown(KeyCode.Space))
        {
            score += 5;

            float colorValue = 1 - (0.2f * score / 5);
            GetComponent<SpriteRenderer>().color = new Color(colorValue, colorValue, colorValue);
            Debug.Log(colorValue);

            // 색깔 변화 주기
            // collision.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Circle")
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Circle")
        {
            isColliding = false;
            pass++;
        }

        if (pass >= 4)
        {
            battle.GiveDamageToEnemy(score);
        }
    }
}