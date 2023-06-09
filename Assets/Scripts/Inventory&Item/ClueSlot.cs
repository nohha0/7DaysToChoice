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

    void Start()
    {
        if(isRare)
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
                txt_line.text = ItemManager.Instance.clueList[clueNumber].line;
            }
        }

    }
}
