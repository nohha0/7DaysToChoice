using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fellow : Character
{
    public GameObject fellowUI;
    string objectName;

    [SerializeField]
    bool onFellowUI = false; //대화, 할일

    public GameObject QkeyUI;
    bool onQkeyUI = false;

    public Fellow(string _name) : base(_name) { }

    private void Start()
    {
        objectName = gameObject.name;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (onQkeyUI)
            {
                if (!onFellowUI)
                {
                    UIController.FellowName = objectName;
                    GameObject.Find("Canvas").transform.Find("FellowUI").gameObject.SetActive(true);
                    onFellowUI = true;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (!onQkeyUI)
            {
                QkeyUI.SetActive(true);
                onQkeyUI = true;
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

        if (onQkeyUI)
        {
            QkeyUI.SetActive(false);
            onQkeyUI = false;
        }
    }
}
