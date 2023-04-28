using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloseToday : MonoBehaviour
{
    UIController controller;
    public GameObject QkeyUI;
    bool On = false;

    void Start()
    {
        controller = GameObject.Find("Canvas").GetComponent<UIController>();
    }

    private void Update()
    {
        if (On && Input.GetKeyDown(KeyCode.Q))
        {
            controller.NextDay(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        On = true;
        QkeyUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        On = false;
        QkeyUI.SetActive(false);
    }

}
