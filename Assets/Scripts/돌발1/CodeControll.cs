using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeControll : MonoBehaviour
{
    public float speed;
    public float addgauge;
    GaugeControll GaugeNum;
    GameManager1 Code;

    //---------------------------
    public bool Redcode;
    void Start()
    {
        GaugeNum = GameObject.Find("∞‘¿Ã¡ˆ").GetComponent<GaugeControll>();
        Code = GameObject.Find("GameManager1").GetComponent<GameManager1>();
    }

    void Update()
    {
        AddCode();
    }

    void AddCode()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Safe")
        {
            if (Input.GetKey(KeyCode.Q))
            {
                Destroy(gameObject);
                GaugeNum.AddGauge(addgauge);

                
            }
            if(Redcode)
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    Debug.Log("∏ÿ√„");
                    Code.StopTrue();
                }
            }
        }
    }
}
