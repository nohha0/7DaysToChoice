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

    //이벤트 순서대로 띄우기
    bool morningEventState = false;
    bool nightEventState = false;
    
    [SerializeField]
    bool Touched = false;

    public GameObject go_BG;
    public Sprite shelterBG;


    // 서신평 제어

    public GameObject ChatActiveTrue;
    public GameObject clueChat;
    public GameObject Chat4;

    void Start()
    {

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            GameManager.Instance.Jung_Yoonwoo.healthPoint -= 30;
        }

        TimeUI();

        if (dialogOn && Input.GetKeyDown(KeyCode.Q))
        {
            if (index >= DialogManager.Instance.SDIndex[DialogManager.Instance.FellowDialogState[fellowNum] + fellowNum + 1] - DialogManager.Instance.SDIndex[DialogManager.Instance.FellowDialogState[fellowNum] + fellowNum])
            {
                GameManager.Instance.AddTimeHour(1);
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
            Debug.Log("하루 종료하고 수면!");
            NextDay(true);
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            GameManager.Instance.AddTimeHour(4);
        }

        if(nightEventState)
        {
            NightEvent();
        }

        if(morningEventState)
        {
            MorningEvent();
        }
    }

    public void CloseFellowUI()
    {
        FellowUI.SetActive(false);
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
                case "신세리":
                    fellowNum = 0;
                    GameManager.Instance.Shin_Seri.love += 10;
                    break;
                case "유화설":
                    fellowNum = 1;
                    GameManager.Instance.Yoo_Hwaseul.love += 10;
                    break;
                case "서신평":
                    fellowNum = 2;
                    GameManager.Instance.Seo_Shinpyeong.love += 10;

                    


                    break;
            }
            Dialog.transform.GetChild(0).GetComponent<Text>().text = DialogManager.Instance.ShelterDialog[DialogManager.Instance.SDIndex[DialogManager.Instance.FellowDialogState[fellowNum] + fellowNum]].Name;
            Dialog.transform.GetChild(1).GetComponent<Text>().text = DialogManager.Instance.ShelterDialog[DialogManager.Instance.SDIndex[DialogManager.Instance.FellowDialogState[fellowNum] + fellowNum]].Line;
            Dialog.transform.GetChild(2).GetComponent<Image>().sprite = DialogManager.Instance.Faces[4 * (fellowNum + 1)];
            Dialog.SetActive(true);
            dialogOn = true;
        }
    }

    public void btnClickLisner()
    {
        switch (FellowName)
        {
            case "신세리":
                break;
            case "유화설":
                break;
            case "서신평":

                ChatActiveTrue.SetActive(true);
                Chat4.SetActive(true);
                clueChat.SetActive(true);

                break;
        }
    }




    public void NightEvent()
    {
        //밤이벤트 : 단서트리 → 호감도밤대화 → 메인 → 돌발 → NextDay

        //GameManager.m_day 증가안된버전

        Touched = true;

        //단서트리

        //호감도밤대화

        //메인, 돌발
        GameManager.Instance.CallNightStory();
    }

    public void MorningEvent()
    {
        //아침이벤트 : 메인 → 아침분배
    }

    public void NextDay(bool alreadyNext)
    {
        blackPanel.SetActive(true);

        if(!alreadyNext)
        {
            GameManager.m_day++;
        }
        GameManager.m_hour = 8;
        GameManager.m_minite = 0;

        //아침배분 끝나는지 검사하고
        //MorningEvent() 실행

        /////////////////////////////////////
        int BeforeDay = GameManager.m_day - 1;

        if (BeforeDay == 6)
        {
            blackPanel.SetActive(true);
            Debug.Log(GameManager.currentNode.Ending);
            EndingText.SetActive(true);
            EndingText.gameObject.GetComponent<Text>().text = GameManager.currentNode.id + " " + GameManager.currentNode.Ending;
        }

        //그냥 넘어가는날~ 이란건 코드 완성하고 나면 없지만 우선은 이렇게 해놓기
        if (BeforeDay == 1 || BeforeDay == 3)
        {
            Invoke("OffPanel", 1f);
        }

        Touched = true;
        MorningShare.SetActive(true); //패널 꺼지기 전에 미리 켜놓는 거였는데 이제 메인 아침꺼 있나 확인하고 가야할듯.

        inNext = false;

        if (BeforeDay == 0)
        {
            SceneManager.LoadScene("Un_Visual");
        }

        if (BeforeDay == 1)
        {
            SceneManager.LoadScene("Un_Event_2");
        }
    }

    public void OffMorningShare()
    {
        MorningShare.SetActive(false);
        Touched = false;
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

    public void LoadSceneExplore()
    {
        SceneManager.LoadScene("Exploration");
        GameManager.Instance.Jung_Yoonwoo.stress -= 15;
        GameManager.Instance.Jung_Yoonwoo.energy -= 20;
    }
}
