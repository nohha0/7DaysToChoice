using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int Time_minute;
    int Time_clock;
    int Day;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TimeUpdate() //�ð� ������Ʈ
    {
        if(Time_clock>=24) //�Ϸ�����
        {
            int over = Time_clock - 24;
            Time_clock = over;
            Day++;
        }
        if (Time_minute >= 60) //�ð� ����
        {
            int over = Time_minute - 60;
            Time_minute = over;
            Time_clock++;
        }
    }

    void TodayOff()  //�Ϸ� ������
    {
        
    }
        
}
