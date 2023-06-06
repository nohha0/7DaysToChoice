using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlimitInventory : MonoBehaviour
{
    public Transform slotsParent;
    public List<GameObject> slots;
    public GameObject slotPrefab;

    void Start()
    {
        UpdateItemUI();

        //현재 있는 슬롯 오브젝트 가져오기.
        for (int i = 0; i < slotsParent.transform.childCount; i++)  
        {
            slots.Add(slotsParent.transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
        
    }

    //탐사에서 돌아왔을 때, 멤버가 가져온거 합칠때
    void AddItemUI(Item _item)
    {
        GameObject newObject = Instantiate(slotPrefab, slotsParent);
        Slot newSlot = newObject.GetComponent<Slot>();
        newSlot.item = _item;
        newSlot.itemImage.sprite = _item.itemSprite;
        slots.Add(newObject.gameObject);

        Debug.Log("아이템 UI 추가 완료");
    }

    //배분 후에?
    void UpdateItemUI()
    {
        foreach(GameObject _slot in slots)
        {
            Destroy(_slot.gameObject);
            Debug.Log("공용인벤 - 있던거다버림");
        }
        slots.Clear();

        foreach (Item _item in ItemManager.Instance.public_Items)
        {
            AddItemUI(_item);
            Debug.Log("공용인벤 - public 리스트에 있는 아이템 추가함");
        }        
    }
}
