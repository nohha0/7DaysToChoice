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
            //�Լ� ȣ���ϸ鼭 score �Ѱ��ֱ� (���ݷ�)
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
