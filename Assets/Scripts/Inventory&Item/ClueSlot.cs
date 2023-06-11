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

    //Ŭ���� �ڼ������� UI ����. �ܼ�n, �̹���, �ؽ�Ʈ
    public GameObject go_readMore;
    public Sprite[] clueSprites = new Sprite[4]; //�Ϲ�0 ���1 ��¥2 ��¥3
    
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
            txt_name.text = "��ʹܼ� " + clue_number.ToString();
            return;
        }
        txt_name.text = "�ܼ� " + clue_number.ToString();

        //Ž�� �� �Ϲ� �ܼ� ȹ�� ������ ������Ʈ �� ��� UI ó��
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
            clueName.text = "��ʹܼ� " + clue_number.ToString();
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

        clueName.text = "�ܼ� " + clue_number.ToString();
        clueText.text = ItemManager.Instance.clueList[clue_number - 1].line;
        clueImage.sprite = clueSprites[0];

        go_readMore.SetActive(true);
    }
}
