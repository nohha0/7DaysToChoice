using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    // �ν��Ͻ��� �����ϱ� ���� ������Ƽ
    public static GameManager Instance
    {
        get
        {
            // �ν��Ͻ��� ���� ��쿡 �����Ϸ� �ϸ� �ν��Ͻ��� �Ҵ����ش�.
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
        // �ν��Ͻ��� �����ϴ� ��� ���λ���� �ν��Ͻ��� �����Ѵ�.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // �Ʒ��� �Լ��� ����Ͽ� ���� ��ȯ�Ǵ��� ����Ǿ��� �ν��Ͻ��� �ı����� �ʴ´�.
        DontDestroyOnLoad(gameObject);
    }


    int Time_Hour;  //���� ���� ����
    int hour; //���� ���� ���оȵ�
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

    void TimeUpdate() //�ð� ������Ʈ
    {
        if (Time_Hour > 24)
        {
            Time_Hour -=24;
        }

        if (Time_minute > 59) //�ð� ����
        {
            Time_minute -= 60;
            Time_Hour++;
        }
        
    }

    void TodayOff()  //�Ϸ� ������
    {
        //�Ϸ� ����Ǹ� �̺�Ʈ ����
        Time_Hour = 8;
        Time_minute = 0;
    }

    public void addTime(int Hour, int min)  //�ð��߰�
    {
        Time_Hour += Hour;
        Time_minute += min;

    }

    public void addDay()  //�����߰�
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
