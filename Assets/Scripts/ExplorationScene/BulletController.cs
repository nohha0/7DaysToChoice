using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public int score = 0;
    public int pass = 0;
    Battle battle;
    private bool isColliding = false;

    //
    private float spaceDelay = 0.2f;
    public GameObject prefab; // 생성할 프리팹
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

            //Debug.Log("왜 안돼");
            spaceDelay = 0.05f;
            score += 5;
            Instantiate(prefab, transform.position, Quaternion.identity);
            float colorValue = 1 - (0.2f * score / 5);
            GetComponent<SpriteRenderer>().color = new Color(colorValue, colorValue, colorValue);
            //Debug.Log(colorValue);

            // 색깔 변화 주기
            // collision.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }

        spaceDelay -= Time.deltaTime;
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