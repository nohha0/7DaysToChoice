using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fellow : Character
{
    public GameObject fellowUI;
    string objectName;

    [SerializeField]
    bool onFellowUI = false;

    public Fellow(string _name) : base(_name) { }

    private void Start()
    {
        objectName = gameObject.name;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (!onFellowUI)
            {
                UIController.FellowName = objectName;
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
