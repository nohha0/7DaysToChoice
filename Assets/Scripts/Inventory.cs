using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //전체 인벤

    

    //일행 개인 인벤

    public static Inventory Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    private int slotCnt;
    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
        }
    }

    void Start()
    {
        SlotCnt = 4;
    }

    void Update()
    {
        
    }
}
