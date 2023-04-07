using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static GameManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
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
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
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

    // Update is called once per frame
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
