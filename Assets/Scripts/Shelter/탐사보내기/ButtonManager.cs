using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Button[] buttons;
    public GameObject[] Char;
    private bool[] buttonPressed;
    private bool[] BeActive; //탐사를 보내면 버튼 자체를 활성화하기 불가하게

    private ColorBlock originalColors;

    //---------------------------------
    public Button exploreButton;
    //---------------------------------
    int[] TimeNow;

    private void Start()
    {

        exploreButton.onClick.AddListener(ExploreButtonClicked);

        buttonPressed = new bool[buttons.Length];
        BeActive = new bool[buttons.Length];

        originalColors = buttons[0].colors; // 첫 번째 버튼의 색상 정보를 기준으로 저장

        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // 클로저에서 사용하기 위한 인덱스 변수 복사
            buttons[i].onClick.AddListener(() => ButtonClicked(index));
        }
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
                string buttonName = GetButtonName(i);
                Debug.Log(buttonName + " 버튼을 탐사합니다.");
                // 추가 동작 수행
                break; // 버튼을 찾았으면 더 이상 검사하지 않고 루프 종료
            }
        }
    }


    string GetButtonName(int index)
    {
        string buttonName = "";
        switch (index)
        {
            case 0:
                buttonName = "Jung";
                SceneManager.LoadScene("Exploration");
                break;
            case 1:
                Char[1].SetActive(false);
                //탐사를 보낸 시간을 저장
                TimeNow[1] = GameManager.m_hour;
                BeActive[1] = true;
                buttonName = "Sua";
                break;
            case 2:
                Char[2].SetActive(false);
                TimeNow[2] = GameManager.m_hour;
                BeActive[2] = true;
                buttonName = "Shin";
                break;
            case 3:
                Char[3].SetActive(false);
                TimeNow[3] = GameManager.m_hour;
                BeActive[3] = true;
                buttonName = "Yuo";
                break;
        }
        return buttonName;
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

                    //아이템 파밍도 해야함
                }
            }
        }
    }
}