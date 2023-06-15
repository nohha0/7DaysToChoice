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


    //������ ��ȭ text â
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

    public void Successful_inference()
    {
        Debug.Log(ItemManager.clue_Number );
        Debug.Log(ItemManager.Rclue_Number);
        if (ItemManager.Rclue_Number ==1)
        {
            if(ItemManager.clue_Number == 19)
            {
                inference.text = "�������̶�, �Ϲ� �ܼ��� ���� ��Ƽ �����Ҵ� �ܺ������� ������� �ʾҴ� ����̾�. ��°������ �𸣰ڳ�.";

                question.text = "�� ������ �����ɱ�?";
                No.text = "����� ������ �־";
                Yes.text = "�Ϲ����� ������ ���ؼ�";

                //���⿡ ��ʹܼ� ���� �̹� �ߴٰ� ���Ӹ޴����� �˸���
            }
            else
            {
                inference.text = "�ƹ����� ������ �ִ� �ܼ��� ã�� ���Ѱ� ����.";

                question.text = "��Ƽ �����Ұ� ������ �������� ���ߵ� ���� ���ؼ�";
                Yes.text = "�Ͼ �� �ϴ�";
                No.text = "�񸮰� �ǽɵȴ�";
            }
        }
        if (ItemManager.Rclue_Number == 2)
        {
            inference.text = "�ƹ����� ������ �ִ� �ܼ��� ã�� ���Ѱ� ����.";

            question.text = "��� �����Ұ� �������� ���� Ȱ���� �� ����";
            Yes.text = "�ٸ� ���𰡰� �ִ�";
            No.text = "���米���� �������̴�";
        }
        if (ItemManager.Rclue_Number == 3)
        {
            if (ItemManager.clue_Number == 11)
            {
                inference.text = "������ �л����� ��� û�ҳ� ��ȣ���� �Ҽ��ΰ� ����, ��ħ ��� ���̿� �����ҵ� ��� û�ҳ� ��ȣ���͸� ������� ����ȸ�� ���� ���׸�. ";


                question.text = "������ �л���� ��Ƽ�������� ���迡 ���ؼ�";
                Yes.text = "������ �ִ�";
                No.text = "������ ����";
            }
            else
            {
                inference.text = "�ƹ����� ������ �ִ� �ܼ��� ã�� ���Ѱ� ����.";

                question.text = "������ �л���� �����Ұ��� ����";
                Yes.text = "��俬���Ұ� �ǽɵȴ�";
                No.text = "��Ƽ�����Ұ� �ǽɵȴ�";
            }
                
        }
        if (ItemManager.Rclue_Number == 4)
        {
            inference.text = "�ƹ����� ������ �ִ� �ܼ��� ã�� ���Ѱ� ����";

            question.text = "��ü���迡 ���ؼ�";
            Yes.text = "��俬���Ұ� �ǽɵȴ�";
            No.text = "��Ƽ�����Ұ� �ǽɵȴ�";
        }
    }

}
