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

    public Button btn1; //대화
    public Button btn2; //의뢰

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
        btn1.onClick.AddListener(() => TimeUp(2, 0));
        btn2.onClick.AddListener(() => TimeUp(2, 0));
    }

    private void Update()
    {
        TimeUI();


        if (dialogOn && Input.GetKeyDown(KeyCode.Q))
        {
            if (index >= GameManager.Instance.SDIndex[GameManager.Instance.FellowDialogState[fellowNum] + fellowNum + 1] - GameManager.Instance.SDIndex[GameManager.Instance.FellowDialogState[fellowNum] + fellowNum])
            {
                Dialog.SetActive(false);
                dialogOn = false;
                Touched = false;
                index = 1;
                GameManager.Instance.FellowDialogState[fellowNum]++;
            }
            else
            {
                Dialog.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.ShelterDialog[GameManager.Instance.SDIndex[GameManager.Instance.FellowDialogState[fellowNum] + fellowNum] + index].Name;
                Dialog.transform.GetChild(1).GetComponent<Text>().text = GameManager.Instance.ShelterDialog[GameManager.Instance.SDIndex[GameManager.Instance.FellowDialogState[fellowNum] + fellowNum] + index].Line;
                index++;
            }

        }

        if (!inNext && GameManager.m_hour >= 2 && GameManager.m_hour <= 7)
        {
            inNext = true;
            Debug.Log("하루 종료하고 수면!");
            NextDay(true);
        }
    }

    public void MoveNode(bool Yes)
    {
        //예, 아니오 방향은 날짜에 따라서 다 다르게 할거지만
        //일단은 예가 맞는 방향으로 간다고 가정하자
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
                case "Shin":
                    fellowNum = 0; break;
                case "Yoo":
                    fellowNum = 1; break;
                case "Seo":
                    fellowNum = 2; break;
            }

            Dialog.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.ShelterDialog[GameManager.Instance.SDIndex[GameManager.Instance.FellowDialogState[fellowNum] + fellowNum]].Name;
            Dialog.transform.GetChild(1).GetComponent<Text>().text = GameManager.Instance.ShelterDialog[GameManager.Instance.SDIndex[GameManager.Instance.FellowDialogState[fellowNum] + fellowNum]].Line;

            Dialog.SetActive(true);
            dialogOn = true;
        }
    }

    public void NextDay(bool alreadyNext)
    {
        blackPanel.SetActive(true);
        
        if (alreadyNext)
        {
            Debug.Log("하루 종료하고 수면! - 강제수면");
            //시간(시,분)만 조작
            GameManager.m_hour = 8;
            GameManager.m_minite = 0;
        }
        else
        {
            Debug.Log("하루 종료하고 수면! - 종료버튼누름");
            
            if(GameManager.m_hour <= 1)
            {
                //시간(시,분)만 조작
                GameManager.m_hour = 8;
                GameManager.m_minite = 0;
            }
            else
            {
                //일차까지 조작
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
        //검은화면 - 이벤트, 트리선택 - 검은화면에 Day N 띄우기
        //이건 코루틴으로 해야겠다...
        //1. 검은 화면 1초간 페이드아웃하고 2초간 유지
        Invoke("FadeIn", 1f);
        Invoke("FadeOut", 6f);

        //2. 만약 특정 일차(2,4,5)라면 clueScreen 띄우기
        int beforeDay = GameManager.m_day - 1;
        if(beforeDay == 2 && beforeDay == 4 && beforeDay == 5)
        {
            Invoke("FadeIn", 2f);
            Invoke("FadeOut", 3f);
        }

        //3. 검은 화면 없애기 전에 dayText 페이드인 1초, 유지 1초, 페이드아웃 1초해서 보여주기
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
        Stat.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.characters[0].characterName;
        Stat.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "에너지 " + GameManager.Instance.characters[0].energy.ToString();
        Stat.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "HP " + GameManager.Instance.characters[0].healthPoint.ToString();
        Stat.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "허기 " + GameManager.Instance.characters[0].hunger.ToString();
        Stat.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "스트레스 " + GameManager.Instance.characters[0].stress.ToString();
        Stat.transform.GetChild(6).GetChild(0).GetComponent<Text>().text = "명성 " + GameManager.Instance.characters[0].fame.ToString();
    }

    public void LoadSceneExplore()
    {
        SceneManager.LoadScene("Exploration");
    }
}
