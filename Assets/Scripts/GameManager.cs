using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int Time_Hour;
    int Time_minute;
    int Day;

    public Text time;

    void Start()
    {
        Time_Hour = 2;
        Time_minute = 5;
        time.text = string.Format("{0:D2} : {1:D2}", Time_Hour, Time_minute);
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
