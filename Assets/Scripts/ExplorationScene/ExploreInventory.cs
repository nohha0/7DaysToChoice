using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreInventory : MonoBehaviour
{
    //탐사 인벤
    public List<SlotData> slots = new List<SlotData>();
    public List<GameObject> slotObjects = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            //에디터에서 슬롯 게임오브젝트들 slotObjects 리스트에 넣었음
            SlotData slot = new SlotData();
            slot.isEmpty = true;
            slot.slotObj = slotObjects[i];
            slots.Add(slot);
        }
    }

    public void DiscardSlotItem(int idx)
    {
        Debug.Log("버리기!");
        if (!slots[idx].isEmpty)
        {
            Debug.Log("버리기 진입!");
            GameObject.Destroy(slots[idx].slotObj.transform.GetChild(1).gameObject);
            slots[idx].isEmpty = true;
        }
    }
}
