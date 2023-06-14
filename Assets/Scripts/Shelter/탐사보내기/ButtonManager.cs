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
    private bool[] BeActive; //Ž�縦 ������ ��ư ��ü�� Ȱ��ȭ�ϱ� �Ұ��ϰ�

    public GameObject Todo;
    public GameObject Stat;

    public Sprite[] charactors;


    private ColorBlock originalColors;

    //---------------------------------
    public Button exploreButton;    //Ž���ư
    public Button statButton;       //�ɷ�ġ��ư
    //---------------------------------
    int[] TimeNow;

    private void Start()
    {

        exploreButton.onClick.AddListener(ExploreButtonClicked);
        statButton.onClick.AddListener(StatButtonClicked);

        buttonPressed = new bool[buttons.Length];
        BeActive = new bool[buttons.Length];

        originalColors = buttons[0].colors; // ù ��° ��ư�� ���� ������ �������� ����

        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Ŭ�������� ����ϱ� ���� �ε��� ���� ����
            buttons[i].onClick.AddListener(() => ButtonClicked(index));
        }
    }

    private void Update()
    {
        BackCheak();
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
                string buttonName = GetExploreButtonName(i);
                Debug.Log(buttonName + " ��ư�� Ž���մϴ�.");
                // �߰� ���� ����
                break; // ��ư�� ã������ �� �̻� �˻����� �ʰ� ���� ����
            }
        }
    }

    void StatButtonClicked()
    {
        for (int i = 0; i < buttonPressed.Length; i++)
        {
            if (buttonPressed[i])
            {
                // ��ư�� ã���� ���� ���� ����
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
                //Ž�縦 ���� �ð��� ����
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
                Stat.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "������ " + GameManager.Instance.Jung_Yoonwoo.energy.ToString();
                Stat.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "HP " + GameManager.Instance.Jung_Yoonwoo.healthPoint.ToString();
                Stat.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "��� " + GameManager.Instance.Jung_Yoonwoo.hunger.ToString();
                Stat.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "��Ʈ���� " + GameManager.Instance.Jung_Yoonwoo.stress.ToString();
                Stat.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "�� " + GameManager.Instance.Jung_Yoonwoo.fame.ToString();
                break;
            case 1:
                Stat.transform.GetChild(0).GetComponent<Image>().sprite = charactors[1];
                Stat.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "������ " + GameManager.Instance.Shin_Seri.energy.ToString();
                Stat.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "HP " + GameManager.Instance.Shin_Seri.healthPoint.ToString();
                Stat.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "��� " + GameManager.Instance.Shin_Seri.hunger.ToString();
                Stat.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "��Ʈ���� " + GameManager.Instance.Shin_Seri.stress.ToString();
                Stat.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "ȣ���� " + GameManager.Instance.Shin_Seri.love.ToString();
                break;
            case 2:
                Stat.transform.GetChild(0).GetComponent<Image>().sprite = charactors[2];
                Stat.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "������ " + GameManager.Instance.Yoo_Hwaseul.energy.ToString();
                Stat.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "HP " + GameManager.Instance.Yoo_Hwaseul.healthPoint.ToString();
                Stat.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "��� " + GameManager.Instance.Yoo_Hwaseul.hunger.ToString();
                Stat.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "��Ʈ���� " + GameManager.Instance.Yoo_Hwaseul.stress.ToString();
                Stat.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "ȣ���� " + GameManager.Instance.Yoo_Hwaseul.love.ToString();
                break;
            case 3:
                Stat.transform.GetChild(0).GetComponent<Image>().sprite = charactors[3];
                Stat.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "������ " + GameManager.Instance.Seo_Shinpyeong.energy.ToString();
                Stat.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "HP " + GameManager.Instance.Seo_Shinpyeong.healthPoint.ToString();
                Stat.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "��� " + GameManager.Instance.Seo_Shinpyeong.hunger.ToString();
                Stat.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "��Ʈ���� " + GameManager.Instance.Seo_Shinpyeong.stress.ToString();
                Stat.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "ȣ���� " + GameManager.Instance.Seo_Shinpyeong.love.ToString();
                break;
        }
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

                    switch (i)  
                    {
                        case 1:
                            //������ �����ϰ� ������
                            ItemManager.instance.
                            break;
                        case 2:
                            break;
                        case 3:
                            break;

                        default:
                            break;
                    }
                    Debug.Log("������ ��������");
                    //������ �Ĺ�++;
                }

            }
        }
    }
}