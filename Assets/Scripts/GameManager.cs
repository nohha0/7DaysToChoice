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

        if (Time_minute >= 60) //�ð� ����
        {
            int over = Time_minute - 60;
            Time_minute = over;
            Time_Hour++;
        }
    }

    void TodayOff()  //�Ϸ� ������
    {
        
    }
        
}
