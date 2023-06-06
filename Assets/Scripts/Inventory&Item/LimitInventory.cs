using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LimitInventory : MonoBehaviour
{
    public Slot[] slots;  // ½½·Ôµé ¹è¿­

    public void AcquireItem(Item _item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].isFill)
            {
                slots[i].AddItem(_item);

                return;
            }
        }
    }
}
