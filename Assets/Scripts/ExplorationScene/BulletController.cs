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
    public GameObject prefab; // ������ ������
    private void Start()
    {
        battle = GameObject.Find("Battle").GetComponent<Battle>();
    }

    private void FixedUpdate()
    {
        // �̵� ó��
        transform.Translate(new Vector3(speed, 0, 0));
    }

    private void Update()
    {
        if (isColliding && Input.GetKeyDown(KeyCode.Space))
        {

            //Debug.Log("�� �ȵ�");
            spaceDelay = 0.05f;
            score += 5;
            Instantiate(prefab, transform.position, Quaternion.identity);
            float colorValue = 1 - (0.2f * score / 5);
            GetComponent<SpriteRenderer>().color = new Color(colorValue, colorValue, colorValue);
            //Debug.Log(colorValue);

            // ���� ��ȭ �ֱ�
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