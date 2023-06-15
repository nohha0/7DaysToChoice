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

    public GameObject BattleUI; //전투 시작
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
        u_Stats.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "에너지 " + GameManager.Instance.Jung_Yoonwoo.energy.ToString();
        u_Stats.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "HP " + GameManager.Instance.Jung_Yoonwoo.healthPoint.ToString();
        u_Stats.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "허기 " + GameManager.Instance.Jung_Yoonwoo.hunger.ToString();
        u_Stats.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "스트레스 " + GameManager.Instance.Jung_Yoonwoo.stress.ToString();
        u_Stats.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "명성 " + GameManager.Instance.Jung_Yoonwoo.fame.ToString();
    }

    public void CloseItem()
    {
        u_Item.SetActive(false);
        Touched = false;
    }

    public void CloseDialog() //선택지 누르면 꺼지게
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

        Debug.Log("조사");
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
        //탐사 아이템 이름을 UI에 띄우기
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
        //이제 여긴 일반 단서 얻는 곳!!
        int clueNumber = Random.Range(1, ItemManager.Instance.rareClueList.Count + 1);
        Debug.Log(clueNumber);

        u_Item.transform.GetChild(1).GetComponent<Text>().text = "단서";
        u_Item.transform.GetChild(2).GetComponent<Image>().sprite = ItemManager.Instance.itemSprites[63];
        u_Item.SetActive(true);
        Invoke("CloseItem", 1f);

        //얻었다고 인덱스로 표시해주기
        ItemManager.Instance.gainedClue.Add(clueNumber);
        inven.AcquireClue();
    }

    public void GetBattle()
    {
        int battleCaseNum = Random.Range(1, 6);
        int oneTwo = Random.Range(1, 3);

        //u_Dialog.transform.GetChild 했을때 순서 : 0이름, 1대사, 2이미지, 선택지(도망친다, 맞서싸운다)

        u_Dialog.SetActive(true);
        u_Choice.SetActive(true);
        u_Dialog.transform.GetChild(0).GetComponent<Text>().text = "낯선 사람";
        u_Dialog.transform.GetChild(2).GetComponent<Image>().sprite = battleImages[oneTwo];
        currentBattleImage = battleImages[oneTwo];
        u_Choice.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "도망친다";
        //도망친다 버튼의 이벤트를 여기서 바꿔야겠다. 
        u_Choice.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(CloseDialog);
        u_Dialog.transform.GetChild(1).GetComponent<Text>().color = Color.white;
        //battleCaseNum = 3;

        switch (battleCaseNum)  
        {
            case 1:
                u_Dialog.transform.GetChild(1).GetComponent<Text>().text = "가진거 다 내놔!!!!";
                u_Choice.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(TryRunAway);
                break; 
            case 2: //곰
                u_Dialog.transform.GetChild(0).GetComponent<Text>().text = "곰";
                u_Dialog.transform.GetChild(1).GetComponent<Text>().text = "크어어어어!!!";
                u_Dialog.transform.GetChild(2).GetComponent<Image>().sprite = battleImages[0];
                currentBattleImage = battleImages[0];
                u_Choice.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(TryRunAway);
                break;
            case 3:
                u_Dialog.transform.GetChild(1).GetComponent<Text>().text = "거기 멈춰! 미안하지만 나도 어쩔 수 없어...가진 식량 다 놓고 떠나...!";
                u_Choice.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "말을 따른다";
                u_Choice.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(DiscardItems);
                break;
            case 4: //싸운다 선택지만 on
                if(oneTwo == 1) u_Dialog.transform.GetChild(1).GetComponent<Text>().text = "남자가 칼을 들며 내게 기습한다.";
                else u_Dialog.transform.GetChild(1).GetComponent<Text>().text = "여자가 뒤에서 날 노린다.";
                u_Dialog.transform.GetChild(1).GetComponent<Text>().color = Color.grey;
                u_Choice.transform.GetChild(0).gameObject.SetActive(false); //도망간다 off
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
            Debug.Log($"{randomNum}가 나와서 붙잡힘");
            StartBattle();
            return;
        }
        Debug.Log($"{randomNum}가 나와서 도망 성공");
        offTouched();
    }

    public void MovePlace(int index)
    {
        if (Touched) return;

        if (index == 8)
        {
            GameManager.Instance.Jung_Yoonwoo.energy -= 30;
            //아이템 옮기기.
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
            //확률로 동료 만나기
            int randomNum = Random.Range(1, 101);
            if(randomNum <= 10)
            {
                Touched = true;
                Debug.Log("동료 만남");
                u_Dialog.transform.GetChild(0).gameObject.GetComponent<Text>().text = "동료중누군가";
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
