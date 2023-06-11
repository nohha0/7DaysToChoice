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
}
