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
    public Image u_Background;

    public GameObject u_Item;
    public GameObject u_Dialog;
    public GameObject u_Check;
    public GameObject u_Choice;

    [SerializeField]
    bool Touched = false;

    private void Start()
    {
    }

    private void Update()
    { }

    public void UpdateStat()
    {
        u_Stats.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "에너지 " + GameManager.Instance.characters[0].energy.ToString();
        u_Stats.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "HP " + GameManager.Instance.characters[0].healthPoint.ToString();
        u_Stats.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "허기 " + GameManager.Instance.characters[0].hunger.ToString();
        u_Stats.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "스트레스 " + GameManager.Instance.characters[0].stress.ToString();
        u_Stats.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = "명성 " + GameManager.Instance.characters[0].fame.ToString();
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!Touched && eventData.pointerCurrentRaycast.gameObject.tag != "otherUI")
        {
            Touched = true;

            Debug.Log("조사");
            int randomNum = Random.Range(1, 101);

            if (randomNum <= 70)
            {
                Debug.Log("아이템"); //아이템
                int index = Random.Range(0, GameManager.Instance.ItemList.Count);
                u_Item.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.ItemList[index].Name;
                u_Item.SetActive(true);
                Invoke("CloseItem", 1f);
            }
            else if (randomNum <= 85)
            {
                Debug.Log("사람조우"); //대화창+선택지
                u_Dialog.transform.GetChild(0).gameObject.GetComponent<Text>().text = "사람";
                u_Dialog.SetActive(true);
                u_Choice.SetActive(true);
            }
            else
            {
                Debug.Log("짐승조우"); //대화창+선택지
                u_Dialog.transform.GetChild(0).gameObject.GetComponent<Text>().text = "짐승";
                u_Dialog.SetActive(true);
                u_Choice.SetActive(true);
            }
        }
        else
        {
            Debug.Log("조사아님");
        }
    }

    public void MovePlace(int index)
    {
        if (index == 8)
        {
            SceneManager.LoadScene("Shelter");
        }
        else
        {
            u_MapButton.SetActive(true);
            u_WorldMap.SetActive(false);
            u_Inventory.SetActive(true);
            u_Stats.SetActive(true);
            u_Background.color = new Color(1f, 0.15f * index, 0.15f * index);
            GameManager.Instance.characters[0].energy -= 10;

            UpdateStat();

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
        }
    }

    public void changeStateWorldMap()
    {
        if(!Touched)
        {
            if (!u_WorldMap.activeSelf)
            {
                u_WorldMap.SetActive(true);
                u_Inventory.SetActive(false);
                u_Stats.SetActive(false);
            }
            else
            {
                u_WorldMap.SetActive(false);
                u_Inventory.SetActive(true);
                u_Stats.SetActive(true);
            }
        }
    }

}
