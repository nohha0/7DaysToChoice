using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public int score = 0;
    public int pass = 0;
    Battle battle;
    

    private void Start()
    {
        battle = GameObject.Find("Battle").GetComponent<Battle>();
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(speed, 0, 0));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Circle" && Input.GetKeyDown(KeyCode.Space))
        {
            score += 5;

            float colorValue = 1 - (0.2f * score / 5);
            GetComponent<SpriteRenderer>().color = new Color(colorValue, colorValue, colorValue);
            Debug.Log(colorValue);

            //색깔변화 주기
            //collision.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Circle")
        {
            pass++;
        }

        if (pass >= 4)
        {
            battle.GiveDamageToEnemy(score);
        }
    }
}
