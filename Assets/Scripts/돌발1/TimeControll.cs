using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControll : MonoBehaviour
{
    public float timeLeft = 60.0f;
    public Text timeText; // UI Text ������Ʈ�� ������ ����
    bool start = false;
    void Start()
    {
        Invoke("StartTime", 3);
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            timeLeft -= Time.deltaTime;

            int timeLeftInt = Mathf.FloorToInt(timeLeft);
            string timeString = timeLeftInt.ToString("D2");

            if (timeLeft - timeLeftInt > 10f)
            {
                timeString = "00";
            }

            timeText.text = timeString; // UI Text ������Ʈ�� text �Ӽ��� ���ڿ��� �Ҵ�
        }
    }

    void StartTime()
    {
        start = true;
    }
    void TimeOver()
    {
        if(timeLeft <=0)
        {
            Debug.Log("TimeOver");
        }
    }
}
