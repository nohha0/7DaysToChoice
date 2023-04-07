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

    void TimeUpdate() //시간 업데이트
    {

        if(Time_Hour <=24)
        {
            Time_Hour = Time_Hour - 24;
        }

        if (Time_minute >= 60) //시간 증가
        {
            int over = Time_minute - 60;
            Time_minute = over;
            Time_Hour++;
        }
    }

    void TodayOff()  //하루 끝내기
    {
        //하루 종료되면 이벤트 전개
        Time_Hour = 8;
        Time_minute = 0;
    }
    public void addTime( int Hour, int min)  //시간추가
    {
        Time_Hour += Hour;
        Time_minute += min;

    }
        
    public void addDay()  //일차추가
    {
        Day++;
    }
}
