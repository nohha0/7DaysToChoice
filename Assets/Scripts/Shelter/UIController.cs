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

    public GameObject Dialog;

    public bool inNext = false;

    public GameObject blackPanel;
    public GameObject clueScreen;
    public GameObject dayText;
    public GameObject EndingText;

    public static string FellowName;

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

    public void OffPanel()
    {
        blackPanel.SetActive(false);
    }

    public void ClickDialog(bool On)
    {
        if (On)
        {
            switch (FellowName)
            {
                case "Yoo":
                    Dialog.transform.GetChild(0).GetComponent<Text>().text = "��ȭ��";
                    Dialog.transform.GetChild(1).GetComponent<Text>().text = GameManager.Instance.Day1Dialogs[11].Line;
                    break;
                case "Seo":
                    Dialog.transform.GetChild(0).GetComponent<Text>().text = "������";
                    Dialog.transform.GetChild(1).GetComponent<Text>().text = GameManager.Instance.Day1Dialogs[18].Line; ;
                    break;
                case "Shin":
                    Dialog.transform.GetChild(0).GetComponent<Text>().text = "�ż���";
                    Dialog.transform.GetChild(1).GetComponent<Text>().text = GameManager.Instance.Day1Dialogs[0].Line; ;
                    break;
            }
            Dialog.SetActive(true);
        }
        
        else Dialog.SetActive(false);
    }

    public void NextDay(bool alreadyNext)
    {
        blackPanel.SetActive(true);
        
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

        if(beforeDay == 6)
        {
            blackPanel.SetActive(true);
            Debug.Log(GameManager.currentNode.Ending);
            EndingText.SetActive(true);
            EndingText.gameObject.GetComponent<Text>().text = GameManager.currentNode.id + " " + GameManager.currentNode.Ending;
        }
       
        if(beforeDay == 1 || beforeDay == 3)
        {
            Invoke("OffPanel", 1f);
        }

        inNext = false;
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

    public void OffToDo()
    {
        Todo.SetActive(false);
    }

    public void OffStat()
    {
        Stat.SetActive(false);
    }

    public void onToDo()
    {
        Todo.SetActive(true);
    }

    public void onStat()
    {
        Todo.SetActive(false);
        Stat.SetActive(true);
        Stat.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.characters[0].characterName;
        Stat.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "������ " + GameManager.Instance.characters[0].energy.ToString();
        Stat.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "HP " + GameManager.Instance.characters[0].healthPoint.ToString();
        Stat.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "��� " + GameManager.Instance.characters[0].hunger.ToString();
        Stat.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "��Ʈ���� " + GameManager.Instance.characters[0].stress.ToString();
        Stat.transform.GetChild(6).GetChild(0).GetComponent<Text>().text = "�� " + GameManager.Instance.characters[0].fame.ToString();
    }

    public void LoadSceneExplore()
    {
        SceneManager.LoadScene("Exploration");
    }
}
