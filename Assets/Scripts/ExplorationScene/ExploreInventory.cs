using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreInventory : MonoBehaviour
{
    //Ž�� �κ�
    public List<SlotData> slots = new List<SlotData>();
    public List<GameObject> slotObjects = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < 5; i++) 
        {
            //�����Ϳ��� ���� ���ӿ�����Ʈ�� slotObjects ����Ʈ�� �־���
            SlotData slot = new SlotData();
            slot.isEmpty = true;
            slot.slotObj = slotObjects[i];
            slots.Add(slot);
        }
    }
}
