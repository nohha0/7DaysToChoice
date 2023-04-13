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

            if (randomNum <= 30)
            {
                Debug.Log("아이템"); //아이템
                u_Item.SetActive(true);
                Invoke("CloseItem", 1f);
            }
            else if (randomNum <= 60)
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
        if(index == 8)
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
