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
    public bool isRare = false; //�ν�����â���� ���� üũ

    void Start()
    {
        if(isRare)
        {
            GetComponent<Image>().color = Color.white;
            txt_name.text = "��ʹܼ� " + clue_number.ToString();
            return;
        }
        txt_name.text = "�ܼ� " + clue_number.ToString();

        //Ž�� �� �Ϲ� �ܼ� ȹ�� ������ ������Ʈ �� ��� UI ó��
        foreach (int clueNumber in ItemManager.Instance.gainedClue)
        {
            if(clueNumber == clue_number)
            {
                txt_line.text = ItemManager.Instance.clueList[clueNumber].line;
            }
        }

    }
}
