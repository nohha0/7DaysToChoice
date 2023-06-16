using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using DG.Tweening;



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
    Tweener tweener;
    public string currentText;
    public bool onTyping;
    public float typingSpeed = 0.1f;


    //----------------------------------------

    public Sprite[] BackGround;
    public GameObject BackG;
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
            tweener.Kill();
            TextLINE.text = null;

            if(!onTyping)
            {
                NextPage();
                Debug.Log("���ٳ�����Q");
                return;
            }

            onTyping = false;
            CancelInvoke();
            TextLINE.text = currentText;
            Debug.Log("���ȳ�������Q");
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
        tweener = (Tweener)TextLINE.DOText(visualDialogs[Points[CurrentNum] + pageIndex].line, visualDialogs[Points[CurrentNum] + pageIndex].line.Length * typingSpeed);
        onTyping = true;
        Invoke("SetOnTypingFalse", visualDialogs[Points[CurrentNum] + pageIndex].line.Length * typingSpeed);
        SetCurrentText(visualDialogs[Points[CurrentNum] + pageIndex].line);
        SetFace();

        if (visualDialogs[Points[CurrentNum] + pageIndex].name == "����")
        {
            TextNAME.text = "";
            TextLINE.color = Color.grey;
            //TextLINE.color = new Color(1f, 1f, 0f);

        }
        else
        {
            TextNAME.text = visualDialogs[Points[CurrentNum] + pageIndex].name;
            TextLINE.color = Color.white;
        }
    }

    //����->�������� �� �Ѿ������ ����
    void SetDialog()
    {
        tweener = (Tweener)TextLINE.DOText(visualDialogs[Points[CurrentNum]].line, visualDialogs[Points[CurrentNum]].line.Length * typingSpeed);
        onTyping = true;
        Invoke("SetOnTypingFalse", visualDialogs[Points[CurrentNum]].line.Length * typingSpeed);
        SetCurrentText(visualDialogs[Points[CurrentNum]].line);
        SetFace();

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

    void KillTweener()
    {
        
    }

    void SetOnTypingFalse()
    {
        onTyping = false;
    }

    void SetCurrentText(string text)
    {
        currentText = text;
    }
    private void FixedUpdate()
    {
        nogada(pageIndex);
    }

    void nogada(int page)
    {
        if (page == 15|| page == 24|| page == 66)
        {
            BackG.GetComponent<SpriteRenderer>().sprite = BackGround[0];

        }
        if (page == 21 || page == 37)
        {
            BackG.GetComponent<SpriteRenderer>().sprite = BackGround[1];



        }
        if (page == 32)
        {

            BackG.GetComponent<SpriteRenderer>().sprite = BackGround[2];
        }
        if (page == 70)
        {

            BackG.GetComponent<SpriteRenderer>().sprite = BackGround[3];
        }



    }
}
