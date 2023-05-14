using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public int score = 0;
    public int pass = 0;

    void Start()
    {
        //GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(speed, 0, 0));
    }

    void Update()
    {
        //transform.Translate(new Vector3(speed, 0, 0));

        if(pass >= 5)
        {
            //함수 호출하면서 score 넘겨주기 (공격량)
            //
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Circle" && Input.GetKeyDown(KeyCode.Space))
        {
            score += 10;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Circle")
        {
            pass++;
        }
    }


}
