using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Fellow : Character
{
    int love = 0;

    public GameObject fellowUI;
    bool onFellowUI = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (!onFellowUI)
            {
                GameObject.Find("Canvas").transform.Find("FellowUI").gameObject.SetActive(true);
                onFellowUI = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (onFellowUI)
        {
            fellowUI.SetActive(false);
            onFellowUI = false;
        }
    }
}
