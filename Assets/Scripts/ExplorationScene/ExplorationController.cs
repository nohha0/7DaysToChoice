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

    void Start()
    {
        
    }

    void Update()
    {
      
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject.tag != "otherUI")
        {
            Debug.Log("조사");
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
        }
    }

    public void changeStateWorldMap()
    {
        if(!u_WorldMap.activeSelf)
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
