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

        if (Time_minute >= 60) //시간 증가
        {
            int over = Time_minute - 60;
            Time_minute = over;
            Time_Hour++;
        }
    }

    void TodayOff()  //하루 끝내기
    {
        
    }
        
}
