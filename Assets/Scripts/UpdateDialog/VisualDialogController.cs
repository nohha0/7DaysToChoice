using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using DG.Tweening;



//메인스토리 씬 : 일차 시간 배경 이름 표정 대사

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

    void Start() //게임에서 메인으로 넘어왔을때
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
                Debug.Log("대사다끝나고Q");
                return;
            }

            onTyping = false;
            CancelInvoke();
            TextLINE.text = currentText;
            Debug.Log("대사안끝났을때Q");
        }
    }

    //다음 대사로 넘길 때
    void NextPage()
    {
        pageIndex++;

        //다 넘겨서 인덱스가 다음 대화에 갔을때
        if (pageIndex == Points[CurrentNum + 1]) 
        {
            CloseDialog();
            DialogUI.SetActive(false);
            return;
        }

        //아직 남았을때
        tweener = (Tweener)TextLINE.DOText(visualDialogs[Points[CurrentNum] + pageIndex].line, visualDialogs[Points[CurrentNum] + pageIndex].line.Length * 0.1f);
        onTyping = true;
        Invoke("SetOnTypingFalse", visualDialogs[Points[CurrentNum] + pageIndex].line.Length * 0.1f);
        SetCurrentText(visualDialogs[Points[CurrentNum] + pageIndex].line);
        SetFace();

        if (visualDialogs[Points[CurrentNum] + pageIndex].name == "독백")
        {
            TextNAME.text = "";
            TextLINE.color = Color.green;
        }
        else
        {
            TextNAME.text = visualDialogs[Points[CurrentNum] + pageIndex].name;
            TextLINE.color = Color.white;
        }
    }

    //게임->메인으로 딱 넘어왔을때 세팅
    void SetDialog()
    {
        tweener = (Tweener)TextLINE.DOText(visualDialogs[Points[CurrentNum]].line, visualDialogs[Points[CurrentNum]].line.Length * 0.1f);
        onTyping = true;
        Invoke("SetOnTypingFalse", visualDialogs[Points[CurrentNum]].line.Length * 0.1f);
        SetCurrentText(visualDialogs[Points[CurrentNum]].line);
        SetFace();

        if (visualDialogs[Points[CurrentNum]].name == "독백")
        {
            TextNAME.text = "";
            TextLINE.color = Color.green;
        }
        else
        {
            TextNAME.text = visualDialogs[Points[CurrentNum]].name;
            TextLINE.color = Color.white;
        }
    }

    //메인->게임으로 갈 때 처리
    void CloseDialog()
    {
        DialogManager.Instance.VisualDialog_CurrentPoints++; //다음 챕터로 넘겨두기
        SceneManager.LoadScene("Shelter");
    }

    void SetFace()
    {
        //우선 엑셀에 표정 기입이 안 됐으니 정색으로만 하자
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
}
