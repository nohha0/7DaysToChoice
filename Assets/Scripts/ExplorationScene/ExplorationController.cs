using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ExplorationController : MonoBehaviour, IPointerClickHandler
{
    public GameObject u_WorldMap;
    public GameObject u_Inventory;
    public GameObject u_Stats;
    public GameObject u_MapButton;
    public GameObject u_Background;
    public GameObject touchArea;
    public List<Sprite> bgimages;

    public GameObject BattleUI; //���� ����
    public GameObject u_Item;
    public GameObject u_Dialog;
    public GameObject u_Check;
    public GameObject u_Choice;
    public LimitInventory inven;
    public Sprite[] battleImages = new Sprite[3];
    Sprite currentBattleImage;

    [SerializeField]
    bool Touched = false;

    private void Start()
    {
    }

    private void Update()
    { }

    public void UpdateStat()
    {
        u_Stats.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "������ " + GameManager.Instance.Jung_Yoonwoo.energy.ToString();
        u_Stats.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "HP " + GameManager.Instance.Jung_Yoonwoo.healthPoint.ToString();
        u_Stats.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "��� " + GameManager.Instance.Jung_Yoonwoo.hunger.ToString();
        u_Stats.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "��Ʈ���� " + GameManager.Instance.Jung_Yoonwoo.stress.ToString();
        u_Stats.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "�� " + GameManager.Instance.Jung_Yoonwoo.fame.ToString();
    }

    public void CloseItem()
    {
        u_Item.SetActive(false);
        Touched = false;
    }

    public void CloseDialog() //������ ������ ������
    {
        u_Dialog.SetActive(false);
        u_Choice.SetActive(false);
        u_Check.SetActive(false);
        Touched = false;
    }

    public void onTouched()
    {
        Touched = true;
    }

    public void offTouched()
    {
        Touched = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (u_WorldMap.activeSelf) return;
        if (Touched) return;

        GameManager.Instance.Jung_Yoonwoo.energy -= Random.Range(2, 4);
        Touched = true;

        Debug.Log("����");
        int randomNum = Random.Range(1, 100);

        if (randomNum <= 70)
        {
            GetItem();
        }
        else if (randomNum <= 80)
        {
            GetClue();
        }
        else if (randomNum <= 100)
        {
            GetBattle();
        }
        int number = Random.Range(2, 4);
        GameManager.Instance.Jung_Yoonwoo.energy -= number;
    }

    public void GetItem()
    {
        //Ž�� ������ �̸��� UI�� ����
        int index = Random.Range(0, ItemManager.Instance.itemDictionary.Count);
        Debug.Log(index);

        u_Item.transform.GetChild(1).GetComponent<Text>().text = ItemManager.Instance.itemDictionary[index].name;
        u_Item.transform.GetChild(2).GetComponent<Image>().sprite = ItemManager.Instance.itemDictionary[index].itemSprite;
        u_Item.SetActive(true);
        Invoke("CloseItem", 1f);

        inven.AcquireItem(ItemManager.Instance.GetItem(index));
    }

    public void GetClue()
    {
        //���� ���� �Ϲ� �ܼ� ��� ��!!
        int clueNumber = Random.Range(1, ItemManager.Instance.rareClueList.Count + 1);
        Debug.Log(clueNumber);

        u_Item.transform.GetChild(1).GetComponent<Text>().text = "�ܼ�";
        u_Item.transform.GetChild(2).GetComponent<Image>().sprite = ItemManager.Instance.itemSprites[63];
        u_Item.SetActive(true);
        Invoke("CloseItem", 1f);

        //����ٰ� �ε����� ǥ�����ֱ�
        ItemManager.Instance.gainedClue.Add(clueNumber);
        inven.AcquireClue();
    }

    public void GetBattle()
    {
        int battleCaseNum = Random.Range(1, 6);
        int oneTwo = Random.Range(1, 3);

        //u_Dialog.transform.GetChild ������ ���� : 0�̸�, 1���, 2�̹���, ������(����ģ��, �¼��ο��)

        u_Dialog.SetActive(true);
        u_Choice.SetActive(true);
        u_Dialog.transform.GetChild(0).GetComponent<Text>().text = "���� ���";
        u_Dialog.transform.GetChild(2).GetComponent<Image>().sprite = battleImages[oneTwo];
        currentBattleImage = battleImages[oneTwo];
        u_Choice.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "����ģ��";
        //����ģ�� ��ư�� �̺�Ʈ�� ���⼭ �ٲ�߰ڴ�. 
        u_Choice.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(CloseDialog);
        u_Dialog.transform.GetChild(1).GetComponent<Text>().color = Color.white;
        //battleCaseNum = 3;

        switch (battleCaseNum)  
        {
            case 1:
                u_Dialog.transform.GetChild(1).GetComponent<Text>().text = "������ �� ����!!!!";
                u_Choice.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(TryRunAway);
                break; 
            case 2: //��
                u_Dialog.transform.GetChild(0).GetComponent<Text>().text = "��";
                u_Dialog.transform.GetChild(1).GetComponent<Text>().text = "ũ�����!!!";
                u_Dialog.transform.GetChild(2).GetComponent<Image>().sprite = battleImages[0];
                currentBattleImage = battleImages[0];
                u_Choice.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(TryRunAway);
                break;
            case 3:
                u_Dialog.transform.GetChild(1).GetComponent<Text>().text = "�ű� ����! �̾������� ���� ��¿ �� ����...���� �ķ� �� ���� ����...!";
                u_Choice.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "���� ������";
                u_Choice.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(DiscardItems);
                break;
            case 4: //�ο�� �������� on
                if(oneTwo == 1) u_Dialog.transform.GetChild(1).GetComponent<Text>().text = "���ڰ� Į�� ��� ���� ����Ѵ�.";
                else u_Dialog.transform.GetChild(1).GetComponent<Text>().text = "���ڰ� �ڿ��� �� �븰��.";
                u_Dialog.transform.GetChild(1).GetComponent<Text>().color = Color.grey;
                u_Choice.transform.GetChild(0).gameObject.SetActive(false); //�������� off
                break;
        }
    }

    public void StartBattle()
    {
        BattleUI.SetActive(true);
        BattleUI.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = currentBattleImage;
    }

    public void DiscardItems()
    {
        inven.DiscardItemAll();
    }

    public void TryRunAway()
    {
        int randomNum = Random.Range(1, 3);

        if(randomNum == 1)
        {
            Debug.Log($"{randomNum}�� ���ͼ� ������");
            StartBattle();
            return;
        }
        Debug.Log($"{randomNum}�� ���ͼ� ���� ����");
        offTouched();
    }

    public void MovePlace(int index)
    {
        if (Touched) return;

        if (index == 8)
        {
            GameManager.Instance.Jung_Yoonwoo.energy -= 30;
            //������ �ű��.
            ItemManager.Instance.MoveItems();
            GameManager.Instance.AddTimeHour(4);
            SceneManager.LoadScene("Shelter");
        }
        else
        {
            u_MapButton.SetActive(true);
            u_WorldMap.SetActive(false);
            u_Inventory.SetActive(true);
            u_Stats.SetActive(true);
            touchArea.SetActive(true);

            u_Background.GetComponent<SpriteRenderer>().sprite = bgimages[index-1];

            GameManager.Instance.Jung_Yoonwoo.energy += -10;
            UpdateStat();

            /*
            //Ȯ���� ���� ������
            int randomNum = Random.Range(1, 101);
            if(randomNum <= 10)
            {
                Touched = true;
                Debug.Log("���� ����");
                u_Dialog.transform.GetChild(0).gameObject.GetComponent<Text>().text = "�����ߴ�����";
                u_Dialog.SetActive(true);
                u_Check.SetActive(true);
            }
            */
        }
    }

    public void changeStateWorldMap()
    {
        if (Touched) return;

        if (!u_WorldMap.activeSelf)
        {
            u_WorldMap.SetActive(true);
            u_Inventory.SetActive(false);
            u_Stats.SetActive(false);
            touchArea.SetActive(false);
        }
        else
        {
            u_WorldMap.SetActive(false);
            u_Inventory.SetActive(true);
            u_Stats.SetActive(true);
            touchArea.SetActive(true);
        }
    }
}
