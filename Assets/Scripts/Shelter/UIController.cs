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

    public GameObject FellowUI;
    public GameObject Dialog;

    public bool inNext = false;

    public GameObject blackPanel;
    public GameObject clueScreen;
    public GameObject dayText;
    public GameObject EndingText;
    public GameObject MorningShare;

    public static string FellowName;
    bool dialogOn = false;
    int fellowNum = 0;
    int index = 1;

    [SerializeField]
    bool Touched = false;

    void Start()
    {
    }

    private void Update()
    {
        TimeUI();

        if (dialogOn && Input.GetKeyDown(KeyCode.Q))
        {
            if (index >= DialogManager.Instance.SDIndex[DialogManager.Instance.FellowDialogState[fellowNum] + fellowNum + 1] - DialogManager.Instance.SDIndex[DialogManager.Instance.FellowDialogState[fellowNum] + fellowNum])
            {
                Dialog.SetActive(false);
                dialogOn = false;
                Touched = false;
                index = 1;
                DialogManager.Instance.FellowDialogState[fellowNum]++;
            }
            else
            {
                Dialog.transform.GetChild(0).GetComponent<Text>().text = DialogManager.Instance.ShelterDialog[DialogManager.Instance.SDIndex[DialogManager.Instance.FellowDialogState[fellowNum] + fellowNum] + index].Name;
                Dialog.transform.GetChild(1).GetComponent<Text>().text = DialogManager.Instance.ShelterDialog[DialogManager.Instance.SDIndex[DialogManager.Instance.FellowDialogState[fellowNum] + fellowNum] + index].Line;
                index++;
            }

        }

        if (!inNext && GameManager.m_hour >= 2 && GameManager.m_hour <= 7)
        {
            inNext = true;
            Debug.Log("�Ϸ� �����ϰ� ����!");
            NextDay(true);
        }
    }


    public void CloseFellowUI()
    {
        FellowUI.SetActive(false);
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
        if (On && !Touched)
        {
            Touched = true;
            
            switch (FellowName)
            {
                case "�ż���":
                    fellowNum = 0; break;
                case "��ȭ��":
                    fellowNum = 1; break;
                case "������":
                    fellowNum = 2; break;
            }

            Dialog.transform.GetChild(0).GetComponent<Text>().text = DialogManager.Instance.ShelterDialog[DialogManager.Instance.SDIndex[DialogManager.Instance.FellowDialogState[fellowNum] + fellowNum]].Name;
            Dialog.transform.GetChild(1).GetComponent<Text>().text = DialogManager.Instance.ShelterDialog[DialogManager.Instance.SDIndex[DialogManager.Instance.FellowDialogState[fellowNum] + fellowNum]].Line;

            Dialog.SetActive(true);
            dialogOn = true;
        }
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

        Touched = true;
        MorningShare.SetActive(true);

        inNext = false;

        if (beforeDay == 1)
        {
            SceneManager.LoadScene("Visual_Unexpected");
        }
    }

    public void OffMorningShare()
    {
        MorningShare.SetActive(false);
        Touched = false;
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
        Touched = false;
    }

    public void OffStat()
    {
        Stat.SetActive(false);
        Touched = false;
    }

    public void onToDo()
    {
        if(!Touched)
        {
            Touched = true;
            Todo.SetActive(true);
        }
    }

    public void onStat()
    {
        Todo.SetActive(false);
        Stat.SetActive(true);
        Stat.transform.GetChild(0).GetComponent<Text>().text = DialogManager.Instance.characters[0].characterName;
        Stat.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "������ " + DialogManager.Instance.characters[0].energy.ToString();
        Stat.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "HP " + DialogManager.Instance.characters[0].healthPoint.ToString();
        Stat.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "��� " + DialogManager.Instance.characters[0].hunger.ToString();
        Stat.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "��Ʈ���� " + DialogManager.Instance.characters[0].stress.ToString();
        Stat.transform.GetChild(6).GetChild(0).GetComponent<Text>().text = "�� " + DialogManager.Instance.characters[0].fame.ToString();
    }

    public void LoadSceneExplore()
    {
        SceneManager.LoadScene("Exploration");
    }
}
