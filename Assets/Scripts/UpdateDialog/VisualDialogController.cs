using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//���ν��丮 �� : ���� �ð� ��� �̸� ǥ�� ���

public class VisualDialogController : MonoBehaviour
{
    public GameObject DialogUI;
    public GameObject CharactorIMAGE;
    public GameObject BackgroundIMAGE;
    Text TextNAME;
    Text TextLINE;
    List<VisualDialog> visualDialogs;
    List<int> Points;
    int CurrentNum;
    int pageIndex = 0;

    void Start() //���ӿ��� �������� �Ѿ������
    {
        TextNAME = DialogUI.transform.GetChild(1).GetComponent<Text>();
        TextLINE = DialogUI.transform.GetChild(2).GetComponent<Text>();
        visualDialogs = DialogManager.Instance.VisualDialog;
        Points = DialogManager.Instance.VisualDialog_StartPoints;
        CurrentNum = DialogManager.Instance.VisualDialog_CurrentPoints;
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
        if (visualDialogs[Points[CurrentNum] + pageIndex].name == "����")
        {
            TextNAME.text = "";
            TextLINE.color = Color.grey;
        }
        else
        {
            TextNAME.text = visualDialogs[Points[CurrentNum] + pageIndex].name;
            TextLINE.color = Color.white;
        }
        TextLINE.text = visualDialogs[Points[CurrentNum] + pageIndex].line;

        SetFace();
    }

    //����->�������� �� �Ѿ������ ����
    void SetDialog()
    {
        if (visualDialogs[Points[CurrentNum]].name == "����")
        {
            TextNAME.text = "";
            TextLINE.color = Color.grey;
        }
        else
        {
            TextNAME.text = visualDialogs[Points[CurrentNum]].name;
            TextLINE.color = Color.white;
        }
        TextLINE.text = visualDialogs[Points[CurrentNum]].line;
        
        SetFace();
    }

    //����->�������� �� �� ó��
    void CloseDialog()
    {
        DialogManager.Instance.VisualDialog_CurrentPoints++; //���� é�ͷ� �Ѱܵα�
        SceneManager.LoadScene("Shelter");
    }

    void SetFace()
    {
        //�켱 ������ ǥ�� ������ �� ������ �������θ� ����
        for (int i = 0; i < 4; i++)
        {   
            if (visualDialogs[Points[CurrentNum] + pageIndex].name.Substring(0, 1) == DialogManager.Instance.chars[i].Substring(0, 1))
            {
                Debug.Log(visualDialogs[Points[CurrentNum] + pageIndex].name.Substring(0, 1));

                //CharactorIMAGE.GetComponent<Image>().color = new Color(1,1,1,1);
                CharactorIMAGE.GetComponent<SpriteRenderer>().sprite = DialogManager.Instance.Faces[i*4];
                return;
            }
        }
        //CharactorIMAGE.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }
}
