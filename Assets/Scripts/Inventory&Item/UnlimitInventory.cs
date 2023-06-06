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

        //���� �ִ� ���� ������Ʈ ��������.
        for (int i = 0; i < slotsParent.transform.childCount; i++)  
        {
            slots.Add(slotsParent.transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
        
    }

    //Ž�翡�� ���ƿ��� ��, ����� �����°� ��ĥ��
    void AddItemUI(Item _item)
    {
        GameObject newObject = Instantiate(slotPrefab, slotsParent);
        Slot newSlot = newObject.GetComponent<Slot>();
        newSlot.item = _item;
        newSlot.itemImage.sprite = _item.itemSprite;
        slots.Add(newObject.gameObject);

        Debug.Log("������ UI �߰� �Ϸ�");
    }

    //��� �Ŀ�?
    void UpdateItemUI()
    {
        foreach(GameObject _slot in slots)
        {
            Destroy(_slot.gameObject);
            Debug.Log("�����κ� - �ִ��Ŵٹ���");
        }
        slots.Clear();

        foreach (Item _item in ItemManager.Instance.public_Items)
        {
            AddItemUI(_item);
            Debug.Log("�����κ� - public ����Ʈ�� �ִ� ������ �߰���");
        }        
    }
}
