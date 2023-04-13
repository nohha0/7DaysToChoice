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

    public GameObject blackPanel;
    public GameObject clueScreen;
    public GameObject dayText;

    public string EndingText;

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

    public void MoveNode(bool Yes)
    {
        //��, �ƴϿ� ������ ��¥�� ���� �� �ٸ��� �Ұ�����
        //�ϴ��� ���� �´� �������� ���ٰ� ��������
        if(Yes)
        {
            GameManager.currentNode = GameManager.currentNode.Left;
            Debug.Log(GameManager.currentNode.id);
        }
        else
        {
            GameManager.currentNode = GameManager.currentNode.Right;
            Debug.Log(GameManager.currentNode.id);
        }
    }
    public void FadeIn(int number)
    {
        if (number == 1) blackPanel.SetActive(true);
        else if (number == 2) clueScreen.SetActive(true);
        else if (number == 3) dayText.SetActive(true);
    }

    public void FadeOut(int number)
    {
        if (number == 1) blackPanel.SetActive(false);
        else if (number == 2) clueScreen.SetActive(false);
        else if (number == 3) dayText.SetActive(false);
    }

    public void NextDay(bool alreadyNext)
    {
        if (alreadyNext)
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

        //NightEvent();

        int beforeDay = GameManager.m_day - 1;
        if (beforeDay == 2 || beforeDay == 4 || beforeDay == 5)
        {
            blackPanel.SetActive(true);
            clueScreen.SetActive(true);
        }

        if(GameManager.m_day == 7)
        {
            blackPanel.SetActive(true);
            Debug.Log(GameManager.currentNode.Ending);
        }
    }

    public void NightEvent()
    {
        //����ȭ�� - �̺�Ʈ, Ʈ������ - ����ȭ�鿡 Day N ����
        //�̰� �ڷ�ƾ���� �ؾ߰ڴ�...
        //1. ���� ȭ�� 1�ʰ� ���̵�ƿ��ϰ� 2�ʰ� ����
        Invoke("FadeIn", 1f);
        Invoke("FadeOut", 6f);

        //2. ���� Ư�� ����(2,4,5)��� clueScreen ����
        int beforeDay = GameManager.m_day - 1;
        if(beforeDay == 2 && beforeDay == 4 && beforeDay == 5)
        {
            Invoke("FadeIn", 2f);
            Invoke("FadeOut", 3f);
        }

        //3. ���� ȭ�� ���ֱ� ���� dayText ���̵��� 1��, ���� 1��, ���̵�ƿ� 1���ؼ� �����ֱ�
        Invoke("FadeIn", 4f);
        Invoke("FadeOut", 5f);
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
