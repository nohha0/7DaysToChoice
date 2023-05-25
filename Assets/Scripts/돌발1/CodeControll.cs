using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeControll : MonoBehaviour
{
    public float speed;
    public float addgauge;
    GaugeControll GaugeNum;
    GameManager Code;

    private bool canPressQ = true;
    private float cooldownTime = 1f;

    //---------------------------
    public bool Redcode;

    void Start()
    {
        GaugeNum = GameObject.Find("∞‘¿Ã¡ˆ").GetComponent<GaugeControll>();
        Code = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            if (!Redcode && Input.GetKey(KeyCode.Q) && canPressQ)
            {
                Destroy(gameObject);
                GaugeNum.AddGauge(addgauge);
                canPressQ = false;
                StartCoroutine(EnableQAfterCooldown());
            }
            if (Redcode)
            {
                if (Input.GetKey(KeyCode.Q) && canPressQ)
                {
                    Debug.Log("∏ÿ√„");
                    Code.StopTrue();
                    canPressQ = false;
                    StartCoroutine(EnableQAfterCooldown());
                    Destroy(gameObject);
                }
            }
        }
    }

    IEnumerator EnableQAfterCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);

        canPressQ = true;
        Debug.Log("Q ¿‘∑¬ ∞°¥…");
    }
}




/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeControll : MonoBehaviour
{
    public float speed;
    public float addgauge;
    GaugeControll GaugeNum;
    GameManager Code;

    private bool canPressQ = true;
    private float cooldownTime = 1f;

    //---------------------------
    public bool Redcode;
    void Start()
    {
        GaugeNum = GameObject.Find("∞‘¿Ã¡ˆ").GetComponent<GaugeControll>();
        Code = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            if (!Redcode && Input.GetKeyDown(KeyCode.Q) && canPressQ)
            {
                Debug.Log("≈Õƒ° ¡¯¬• æ»µ∆øÚ?");
                Destroy(gameObject);
                GaugeNum.AddGauge(addgauge);
                canPressQ = false;
                Invoke(nameof(ResetCooldown), cooldownTime);
            }
            if (Redcode)
            {
                if (Input.GetKeyDown(KeyCode.Q) && canPressQ)
                {
                    Debug.Log("∏ÿ√„");
                    Code.StopTrue();
                    canPressQ = false;
                    Invoke(nameof(ResetCooldown), cooldownTime);
                }
            }
        }
    }
    private void ResetCooldown()
    {
        canPressQ = true;
        Debug.Log("0√  º¬");
    }
}*/
