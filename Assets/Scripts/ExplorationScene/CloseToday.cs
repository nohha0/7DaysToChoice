using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseToday : MonoBehaviour
{
    UIController controller;

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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        On = false;
    }

}
