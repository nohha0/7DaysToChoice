using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int Time_minute = 0;
    int Time_Hour = 14;
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

        if(Time_Hour <=24)
        {
            Time_Hour = Time_Hour - 24;
        }

        if (Time_minute >= 60) //�ð� ����
        {
            int over = Time_minute - 60;
            Time_minute = over;
            Time_Hour++;
        }
    }

    void TodayOff()  //�Ϸ� ������
    {
        //�Ϸ� ����Ǹ� �̺�Ʈ ����
        Time_Hour = 8;
        Time_minute = 0;
    }
    public void addTime( int Hour, int min)  //�ð��߰�
    {
        Time_Hour += Hour;
        Time_minute += min;

    }
        
    public void addDay()  //�����߰�
    {
        Day++;
    }
}
