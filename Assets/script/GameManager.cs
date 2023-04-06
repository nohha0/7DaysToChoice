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

    void TimeUpdate() //시간 업데이트
    {
        if(Time_clock>=24) //하루증가
        {
            int over = Time_clock - 24;
            Time_clock = over;
            Day++;
        }
        if (Time_minute >= 60) //시간 증가
        {
            int over = Time_minute - 60;
            Time_minute = over;
            Time_clock++;
        }
    }

    void TodayOff()  //하루 끝내기
    {
        
    }
        
}
