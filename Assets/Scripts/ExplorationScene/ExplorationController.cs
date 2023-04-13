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

    public void CloseDialog() //������ ������ ������
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

            Debug.Log("����");
            int randomNum = Random.Range(1, 101);

            if (randomNum <= 30)
            {
                Debug.Log("������"); //������
                u_Item.SetActive(true);
                Invoke("CloseItem", 1f);
            }
            else if (randomNum <= 60)
            {
                Debug.Log("�������"); //��ȭâ+������
                u_Dialog.transform.GetChild(0).gameObject.GetComponent<Text>().text = "���";
                u_Dialog.SetActive(true);
                u_Choice.SetActive(true);
            }
            else
            {
                Debug.Log("��������"); //��ȭâ+������
                u_Dialog.transform.GetChild(0).gameObject.GetComponent<Text>().text = "����";
                u_Dialog.SetActive(true);
                u_Choice.SetActive(true);
            }
        }
        else
        {
            Debug.Log("����ƴ�");
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
