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
    private bool[] BeActive; //Ž�縦 ������ ��ư ��ü�� Ȱ��ȭ�ϱ� �Ұ��ϰ�

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

        originalColors = buttons[0].colors; // ù ��° ��ư�� ���� ������ �������� ����

        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Ŭ�������� ����ϱ� ���� �ε��� ���� ����
            buttons[i].onClick.AddListener(() => ButtonClicked(index));
        }
    }

    private void ButtonClicked(int buttonIndex)
    {
        // �ٸ� ��ư�� �̹� ���ȴ��� Ȯ���ϰ� �ִٸ� �ش� ��ư�� ���� ���¸� �ʱ�ȭ
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i != buttonIndex && buttonPressed[i])
            {
                buttonPressed[i] = false;
                ResetButtonColor(buttons[i]);
                Debug.Log(buttons[i].name + " ��ư�� ���� ���¸� �ʱ�ȭ�߽��ϴ�.");
            }
        }

        // ���� ��ư�� ���� ���¸� ����
        buttonPressed[buttonIndex] = true;
        ResetButtonColor(buttons[buttonIndex]);
        Debug.Log(buttons[buttonIndex].name + " ��ư�� ���Ƚ��ϴ�.");
    }

    private void ResetButtonColor(Button button)
    {
        // ��ư�� ������ �Ϲ� ���·� ����
        ColorBlock colors = button.colors;
        colors.normalColor = originalColors.normalColor;
        button.colors = colors;
    }


    //Ž���ϱ� ������ ����Ǵ� ������
    void ExploreButtonClicked()
    {
        for (int i = 0; i < buttonPressed.Length; i++)
        {
            if (buttonPressed[i])
            {
                // ��ư�� ã���� ���� ���� ����
                string buttonName = GetButtonName(i);
                Debug.Log(buttonName + " ��ư�� Ž���մϴ�.");
                // �߰� ���� ����
                break; // ��ư�� ã������ �� �̻� �˻����� �ʰ� ���� ����
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
                //Ž�縦 ���� �ð��� ����
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
    
    //Ž�� ���ٿ� ������ ���ƿԴ��� üũ
    void BackCheak()
    {
        for(int i = 0;i < BeActive.Length; i++)
        {
            //Ž�縦 �� ��ü���� Ȯ��
            if(BeActive[i])
            {
                //Ž�翡�� ���ƿ� �ð�
                if(GameManager.m_hour <= (TimeNow[i]+4))
                {

                    BeActive[i] = false;  //Ž�� ����
                    Char[i].SetActive(true);  //���ӿ�����Ʈ Ȱ��ȭ

                    //������ �Ĺֵ� �ؾ���
                }
            }
        }
    }
}