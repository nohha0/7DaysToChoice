using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueSlot : MonoBehaviour
{
    public Text txt_name;
    public Text txt_line;
    public Clue clue;

    public int clue_number;
    public bool isGained = false;
    public bool isRare = false; //인스펙터창에서 직접 체크

    //클릭시 자세히보기 UI 띄우기. 단서n, 이미지, 텍스트
    public GameObject go_readMore;
    public Sprite[] clueSprites = new Sprite[4]; //일반0 희귀1 진짜2 가짜3
    
    Image clueImage;
    Text clueName;
    Text clueText;


    //서신평 대화 text 창
    public Text inference;
    public Text question;
    public Text Yes;
    public Text No;



    void Start()
    {
        clueImage = go_readMore.transform.GetChild(1).GetComponent<Image>();
        clueName = go_readMore.transform.GetChild(2).GetComponent<Text>();
        clueText = go_readMore.transform.GetChild(3).GetComponent<Text>();

        if (isRare)
        {
            GetComponent<Image>().color = Color.white;
            txt_name.text = "희귀단서 " + clue_number.ToString();
            return;
        }
        txt_name.text = "단서 " + clue_number.ToString();

        //탐사 후 일반 단서 획득 정보가 업데이트 된 경우 UI 처리
        foreach (int clueNumber in ItemManager.Instance.gainedClue)
        {
            if(clueNumber == clue_number)
            {
                isGained = true;
                txt_line.text = ItemManager.Instance.clueList[clueNumber].line;
            }
        }
    }

    public void ReadMore()
    {
        if (!isGained) return;

        if(go_readMore.activeSelf)
        {
            go_readMore.SetActive(false);
            return;
        }

        if (isRare)
        {
            clueName.text = "희귀단서 " + clue_number.ToString();
            clueText.text = ItemManager.Instance.rareClueList[clue_number - 1].line;

            switch (clue_number)    
            {
                case 1:
                    clueImage.sprite = clueSprites[3];
                    break;
                case 2:
                    clueImage.sprite = clueSprites[2];
                    break;
                default:
                    clueImage.sprite = clueSprites[1];
                    break;
            }
            go_readMore.SetActive(true);
            return;
        }

        clueName.text = "단서 " + clue_number.ToString();
        clueText.text = ItemManager.Instance.clueList[clue_number - 1].line;
        clueImage.sprite = clueSprites[0];

        go_readMore.SetActive(true);
    }

    public void Successful_inference()
    {
        Debug.Log(ItemManager.clue_Number );
        Debug.Log(ItemManager.Rclue_Number);
        if (ItemManager.Rclue_Number ==1)
        {
            if(ItemManager.clue_Number == 19)
            {
                inference.text = "맑은물이라, 일반 단서를 보니 바티 연구소는 외부접근을 허용하지 않았던 모양이야. 어째서인진 모르겠네.";

                question.text = "왜 접근을 막은걸까?";
                No.text = "숨기고 싶은게 있어서";
                Yes.text = "일반인의 안전을 위해서";

                //여기에 희귀단서 조합 이미 했다고 게임메니저에 알리기
            }
            else
            {
                inference.text = "아무래도 연관성 있는 단서는 찾지 못한것 같군.";

                question.text = "바티 연구소가 우수기관 인증제에 선발된 점에 대해서";
                Yes.text = "믿어볼 만 하다";
                No.text = "비리가 의심된다";
            }
        }
        if (ItemManager.Rclue_Number == 2)
        {
            inference.text = "아무래도 연관성 있는 단서는 찾지 못한것 같군.";

            question.text = "비긴 연구소가 적극적인 교육 활동을 한 이유";
            Yes.text = "다른 무언가가 있다";
            No.text = "인재교육에 적극적이다";
        }
        if (ItemManager.Rclue_Number == 3)
        {
            if (ItemManager.clue_Number == 11)
            {
                inference.text = "실종된 학생들은 희망 청소년 보호센터 소속인것 같군, 마침 비긴 바이오 연구소도 희망 청소년 보호센터를 대상으로 설명회를 연것 같네만. ";


                question.text = "실종된 학생들과 바티연구소의 관계에 대해서";
                Yes.text = "관련이 있다";
                No.text = "관련이 없다";
            }
            else
            {
                inference.text = "아무래도 연관성 있는 단서는 찾지 못한것 같군.";

                question.text = "실종된 학생들과 연구소간의 관련";
                Yes.text = "비긴연구소가 의심된다";
                No.text = "바티연구소가 의심된다";
            }
                
        }
        if (ItemManager.Rclue_Number == 4)
        {
            inference.text = "아무래도 연관성 있는 단서는 찾지 못한것 같군";

            question.text = "생체실험에 대해서";
            Yes.text = "비긴연구소가 의심된다";
            No.text = "바티연구소가 의심된다";
        }
    }

}
