using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    GameObject Btn;
    
    void Start()
    {
        Btn = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        
    }

    public void ClickBtn()
    {
        if(!Btn.activeSelf)
        {
            Btn.SetActive(true);
        }
        else
        {
            Btn.SetActive(false);
        }
    }
}
