using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    GameObject discardBtn;
    
    void Start()
    {
        discardBtn = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        
    }

    public void ClickSlot()
    {
        if(!discardBtn.activeSelf)
        {
            discardBtn.SetActive(true);
        }
        else
        {
            discardBtn.SetActive(false);
        }
    }
}
