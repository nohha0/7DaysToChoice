using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    int Time_Hour;  //오전 오후 구분
    int hour; //오전 오후 구분안됨
    int Time_minute;
    int Day;

    public Text time;

    void Start()
    {
        Time_Hour = 13;
        Time_minute = 65;
        Day = 1;
    }

    void Update()
    {
        UITime();
    }

    void TimeUpdate() //시간 업데이트
    {
        if (Time_Hour > 24)
        {
            Time_Hour -=24;
        }

        if (Time_minute > 59) //시간 증가
        {
            Time_minute -= 60;
            Time_Hour++;
        }
        
    }

    void TodayOff()  //하루 끝내기
    {
        //하루 종료되면 이벤트 전개
        Time_Hour = 8;
        Time_minute = 0;
    }

    public void addTime(int Hour, int min)  //시간추가
    {
        Time_Hour += Hour;
        Time_minute += min;

    }

    public void addDay()  //일차추가
    {
        Day++;
    }

    void UITime()
    {
        TimeUpdate();

        if (Time_Hour > 12)
        {
            time.text = string.Format("DAY {0}  PM {1:D2} : {2:D2}", Day, Time_Hour - 12, Time_minute);
        }
        else
        {
            time.text = string.Format("DAY {0}  AM {1:D2} : {2:D2}", Day, Time_Hour, Time_minute);
        }
        
    }
}
