using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;

public class ButtonManager : MonoBehaviour
{
    public Button[] buttons;
    public GameObject[] Char;
    private bool[] buttonPressed;
    private bool[] BeActive; //탐사를 보내면 버튼 자체를 활성화하기 불가하게

    public GameObject Todo;
    public GameObject Stat;

    public Sprite[] charactors;


    private ColorBlock originalColors;

    //---------------------------------
    public Button exploreButton;    //탐사버튼
    public Button statButton;       //능력치버튼
    //---------------------------------
    int[] TimeNow;

    private void Start()
    {

        exploreButton.onClick.AddListener(ExploreButtonClicked);
        statButton.onClick.AddListener(StatButtonClicked);

        buttonPressed = new bool[buttons.Length];
        BeActive = new bool[buttons.Length];

        originalColors = buttons[0].colors; // 첫 번째 버튼의 색상 정보를 기준으로 저장

        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // 클로저에서 사용하기 위한 인덱스 변수 복사
            buttons[i].onClick.AddListener(() => ButtonClicked(index));
        }
    }

    private void Update()
    {
        BackCheak();
    }



    private void ButtonClicked(int buttonIndex)
    {
        // 다른 버튼이 이미 눌렸는지 확인하고 있다면 해당 버튼의 눌림 상태를 초기화
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i != buttonIndex && buttonPressed[i])
            {
                buttonPressed[i] = false;
                ResetButtonColor(buttons[i]);
                Debug.Log(buttons[i].name + " 버튼의 눌림 상태를 초기화했습니다.");
            }
        }

        // 현재 버튼의 눌림 상태를 설정
        buttonPressed[buttonIndex] = true;
        ResetButtonColor(buttons[buttonIndex]);
        Debug.Log(buttons[buttonIndex].name + " 버튼이 눌렸습니다.");
    }

    private void ResetButtonColor(Button button)
    {
        // 버튼의 색상을 일반 상태로 변경
        ColorBlock colors = button.colors;
        colors.normalColor = originalColors.normalColor;
        button.colors = colors;
    }


    //탐사하기 누르면 실행되는 리스너
    void ExploreButtonClicked()
    {
        for (int i = 0; i < buttonPressed.Length; i++)
        {
            if (buttonPressed[i])
            {
                // 버튼을 찾았을 때의 동작 수행
                string buttonName = GetExploreButtonName(i);
                Debug.Log(buttonName + " 버튼을 탐사합니다.");
                // 추가 동작 수행
                break; // 버튼을 찾았으면 더 이상 검사하지 않고 루프 종료
            }
        }
    }

    void StatButtonClicked()
    {
        for (int i = 0; i < buttonPressed.Length; i++)
        {
            if (buttonPressed[i])
            {
                // 버튼을 찾았을 때의 동작 수행
                GetStatButtonName(i);
                break;
            }
        }
    }


    string GetExploreButtonName(int index)
    {
        string buttonName = "";
        switch (index)
        {
            case 0:
                buttonName = "Jung";
                SceneManager.LoadScene("Exploration");
                break;
            case 1:
                if(GameManager.Instance.Shin_Seri.energy <= 30 || GameManager.Instance.Shin_Seri.stress >= 70 || GameManager.Instance.Shin_Seri.healthPoint <= 30)
                {
                    break;
                }
                Char[1].SetActive(false);
                //탐사를 보낸 시간을 저장
                TimeNow[1] = GameManager.m_hour;
                BeActive[1] = true;
                buttonName = "Shin";
                GameManager.Instance.Shin_Seri.stress -= 15;
                GameManager.Instance.Shin_Seri.energy -= 20;
                break;
            case 2:
                if (GameManager.Instance.Yoo_Hwaseul.energy <= 30 || GameManager.Instance.Yoo_Hwaseul.stress >= 70 || GameManager.Instance.Yoo_Hwaseul.healthPoint <= 30)
                {
                    break;
                }
                Char[2].SetActive(false);
                TimeNow[2] = GameManager.m_hour;
                BeActive[2] = true;
                buttonName = "Yuo";
                GameManager.Instance.Yoo_Hwaseul.stress -= 15;
                GameManager.Instance.Yoo_Hwaseul.energy -= 20;
                break;
            case 3:
                if (GameManager.Instance.Seo_Shinpyeong.energy <= 30 || GameManager.Instance.Seo_Shinpyeong.stress >= 70 || GameManager.Instance.Seo_Shinpyeong.healthPoint <= 30)
                {
                    break;
                }
                Char[3].SetActive(false);
                TimeNow[3] = GameManager.m_hour;
                BeActive[3] = true;
                buttonName = "Seo";
                GameManager.Instance.Seo_Shinpyeong.stress -= 15;
                GameManager.Instance.Seo_Shinpyeong.energy -= 20;
                break;
        }
        return buttonName;
    }

    void GetStatButtonName(int index)
    {
        onStat(index);
        return;
    }

    public void onStat(int member)
    {
        Todo.SetActive(false);
        Stat.SetActive(true);

        switch(member)
        {
            case 0:
                Stat.transform.GetChild(0).GetComponent<Image>().sprite = charactors[0];
                Stat.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "에너지 " + GameManager.Instance.Jung_Yoonwoo.energy.ToString();
                Stat.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "HP " + GameManager.Instance.Jung_Yoonwoo.healthPoint.ToString();
                Stat.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "허기 " + GameManager.Instance.Jung_Yoonwoo.hunger.ToString();
                Stat.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "스트레스 " + GameManager.Instance.Jung_Yoonwoo.stress.ToString();
                Stat.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "명성 " + GameManager.Instance.Jung_Yoonwoo.fame.ToString();
                break;
            case 1:
                Stat.transform.GetChild(0).GetComponent<Image>().sprite = charactors[1];
                Stat.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "에너지 " + GameManager.Instance.Shin_Seri.energy.ToString();
                Stat.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "HP " + GameManager.Instance.Shin_Seri.healthPoint.ToString();
                Stat.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "허기 " + GameManager.Instance.Shin_Seri.hunger.ToString();
                Stat.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "스트레스 " + GameManager.Instance.Shin_Seri.stress.ToString();
                Stat.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "호감도 " + GameManager.Instance.Shin_Seri.love.ToString();
                break;
            case 2:
                Stat.transform.GetChild(0).GetComponent<Image>().sprite = charactors[2];
                Stat.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "에너지 " + GameManager.Instance.Yoo_Hwaseul.energy.ToString();
                Stat.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "HP " + GameManager.Instance.Yoo_Hwaseul.healthPoint.ToString();
                Stat.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "허기 " + GameManager.Instance.Yoo_Hwaseul.hunger.ToString();
                Stat.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "스트레스 " + GameManager.Instance.Yoo_Hwaseul.stress.ToString();
                Stat.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "호감도 " + GameManager.Instance.Yoo_Hwaseul.love.ToString();
                break;
            case 3:
                Stat.transform.GetChild(0).GetComponent<Image>().sprite = charactors[3];
                Stat.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "에너지 " + GameManager.Instance.Seo_Shinpyeong.energy.ToString();
                Stat.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "HP " + GameManager.Instance.Seo_Shinpyeong.healthPoint.ToString();
                Stat.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "허기 " + GameManager.Instance.Seo_Shinpyeong.hunger.ToString();
                Stat.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "스트레스 " + GameManager.Instance.Seo_Shinpyeong.stress.ToString();
                Stat.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "호감도 " + GameManager.Instance.Seo_Shinpyeong.love.ToString();
                break;
        }
    }

    //탐사 갔다온 일행이 돌아왔는지 체크
    void BackCheak()
    {
        for(int i = 0;i < BeActive.Length; i++)
        {
            //탐사를 간 객체인지 확인
            if(BeActive[i])
            {
                //탐사에서 돌아올 시간
                if(GameManager.m_hour <= (TimeNow[i]+4))
                {

                    BeActive[i] = false;  //탐사 종료
                    Char[i].SetActive(true);  //게임오브젝트 활성화

                    switch (i)  
                    {
                        case 1:
                            //아이템 랜덤하게 얻어오기
                            ItemManager.instance.
                            break;
                        case 2:
                            break;
                        case 3:
                            break;

                        default:
                            break;
                    }
                    Debug.Log("아이템 가져왔음");
                    //아이템 파밍++;
                }

            }
        }
    }
}