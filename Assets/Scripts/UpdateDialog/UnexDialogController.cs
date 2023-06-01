using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnexDialogController : MonoBehaviour
{
    public GameObject DialogUI;
    public GameObject CharactorIMAGE;
    public GameObject BackgroundIMAGE;
    Text TextNAME;
    Text TextLINE;
    List<UnexpectedDialog> unexpectedDialogs;
    List<int> Points;
    int CurrentNum;
    int pageIndex = 0;

    void Start() //���ӿ��� ���߷� �Ѿ������
    {
        TextNAME = DialogUI.transform.GetChild(1).GetComponent<Text>();
        TextLINE = DialogUI.transform.GetChild(2).GetComponent<Text>();
        unexpectedDialogs = DialogManager.Instance.UnexpectedDialog;
        Points = DialogManager.Instance.UnexpDialog_StartPoints;
        CurrentNum = DialogManager.Instance.UnexpDialog_CurrentPoints;
        SetDialog();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            NextPage();
        }
    }

    //���� ���� �ѱ� ��
    void NextPage()
    {
        pageIndex++;

        //�� �Ѱܼ� �ε����� ���� ��ȭ�� ������
        if (pageIndex == Points[CurrentNum + 1])
        {
            CloseDialog();
            DialogUI.SetActive(false);
            return;
        }

        //���� ��������
        if (unexpectedDialogs[Points[CurrentNum] + pageIndex].name == "����")
        {
            TextNAME.text = "";
            TextLINE.color = Color.grey;
        }
        else
        {
            TextNAME.text = unexpectedDialogs[Points[CurrentNum] + pageIndex].name;
            TextLINE.color = Color.white;
        }
        TextLINE.text = unexpectedDialogs[Points[CurrentNum] + pageIndex].line;

        SetFace();
    }

    //����->���߷� �� �Ѿ������ ����
    void SetDialog()
    {
        if (unexpectedDialogs[Points[CurrentNum]].name == "����")
        {
            TextNAME.text = "";
            TextLINE.color = Color.grey;
        }
        else
        {
            TextNAME.text = unexpectedDialogs[Points[CurrentNum]].name;
            TextLINE.color = Color.white;
        }
        TextLINE.text = unexpectedDialogs[Points[CurrentNum]].line;

        SetFace();
    }

    //����->���߰������� �� �� ó��
    void CloseDialog()
    {
        DialogManager.Instance.UnexpDialog_CurrentPoints++; //���� é�ͷ� �Ѱܵα�
        SceneManager.LoadScene("Un_Event_1");
    }

    void SetFace()
    {
        //�켱 ������ ǥ�� ������ �� ������ �������θ� ����
        for (int i = 0; i < 4; i++)
        {
            if (unexpectedDialogs[Points[CurrentNum] + pageIndex].name.Substring(0, 1) == DialogManager.Instance.chars[i].Substring(0, 1))
            {
                Debug.Log(unexpectedDialogs[Points[CurrentNum] + pageIndex].name.Substring(0, 1));

                //CharactorIMAGE.GetComponent<Image>().color = new Color(1,1,1,1);
                CharactorIMAGE.GetComponent<SpriteRenderer>().sprite = DialogManager.Instance.Faces[i * 4];
                return;
            }
        }
        //CharactorIMAGE.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }
}
