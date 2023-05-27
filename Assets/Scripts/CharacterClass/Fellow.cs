using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fellow : MonoBehaviour
{
    public GameObject[] ShelterDialogUI = new GameObject[5];
    public string[] ShelterDialog = new string[4];
    public GameObject fellowUI;
    string objectName;
    public UIController uiController;

    [SerializeField]
    bool onFellowUI = false; //��ȭ, ����

    public GameObject QkeyUI;
    bool onQkeyUI = false;

    private void Start()
    {
        objectName = gameObject.name;
        uiController = GameObject.Find("Canvas").GetComponent<UIController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (onQkeyUI)
            {
                if (!onFellowUI)
                {
                    UIController.FellowName = objectName;
                    GameObject.Find("Canvas").transform.Find("FellowUI").gameObject.SetActive(true);
                    onFellowUI = true;

                    PressFellow();
                }
            }
        }
    }


    //Q�������� ó�� ������ ��ȭâ�� ĳ���� ���ݿ� �´� ���� ������ �־��ִ� �Լ�
    public void PressFellow()
    {
        ShelterDialogUI[0].GetComponent<Text>().text = objectName;

        for (int i = 1; i < 5; i++)
        {
            ShelterDialogUI[i].GetComponent<Text>().text = ShelterDialog[i-1];
        }

        fellowUI.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (!onQkeyUI)
            {
                QkeyUI.SetActive(true);
                onQkeyUI = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (onFellowUI)
        {
            fellowUI.SetActive(false);
            onFellowUI = false;
        }

        if (onQkeyUI)
        {
            QkeyUI.SetActive(false);
            onQkeyUI = false;
        }
    }
}
