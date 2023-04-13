using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject Todo;
    public GameObject Stat;

    public Text time;

    public Button btn1; //��ȭ
    public Button btn2; //�Ƿ�

    public bool inNext = false;

    void Start()
    {
        btn1.onClick.AddListener(() => TimeUp(4, 0));
        btn2.onClick.AddListener(() => TimeUp(4, 0));
    }

    private void Update()
    {
        TimeUI();

        if(!inNext && GameManager.m_hour >= 2 && GameManager.m_hour <= 7)
        {
            inNext = true;
            Debug.Log("�Ϸ� �����ϰ� ����!");
            NextDay(true);
        }
    }

    public void NextDay(bool alreadyNext)
    {
        //����ȭ�� - �̺�Ʈ, Ʈ������ - ����ȭ�鿡 Day N ����



        if(alreadyNext)
        {
            Debug.Log("�Ϸ� �����ϰ� ����! - ��������");
            //�ð�(��,��)�� ����
            GameManager.m_hour = 8;
            GameManager.m_minite = 0;
        }
        else
        {
            Debug.Log("�Ϸ� �����ϰ� ����! - �����ư����");
            
            if(GameManager.m_hour <= 1)
            {
                //�ð�(��,��)�� ����
                GameManager.m_hour = 8;
                GameManager.m_minite = 0;
            }
            else
            {
                //�������� ����
                GameManager.m_day++;
                GameManager.m_hour = 8;
                GameManager.m_minite = 0;
            }
        }
    }

    public void TimeUp(int hour, int minite)
    {
        GameManager.Instance.AddTime(hour, minite);
    }

    void TimeUI()
    {
        if (GameManager.m_hour >= 13)
        {
            time.text = string.Format("DAY {0}   PM {1:D2}:{2:D2}", GameManager.m_day, GameManager.m_hour - 12, GameManager.m_minite);
        }
        else
        {
            time.text = string.Format("DAY {0}   AM {1:D2}:{2:D2}", GameManager.m_day, GameManager.m_hour, GameManager.m_minite);
        }
    }

    public void onToDo()
    {
        Todo.SetActive(true);
    }

    public void onStat()
    {
        Todo.SetActive(false);
        Stat.SetActive(true);
    }

    public void LoadSceneExplore()
    {
        SceneManager.LoadScene("Exploration");
    }
}
