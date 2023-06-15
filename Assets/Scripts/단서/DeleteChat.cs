using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteChat : MonoBehaviour
{
    public GameObject[] Chat;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.clue1)
        {
            Chat[0].SetActive(false);
        }
        if (!GameManager.Instance.clue2)
        {
            Chat[1].SetActive(false);
        }
        if (!GameManager.Instance.clue3)
        {
            Chat[2].SetActive(false);
        }
        if (!GameManager.Instance.clue4)
        {
            Chat[3].SetActive(false);
        }
    }

    public void ChatFalse(int a)
    {
        switch(a)
        {
            case 1:
                GameManager.Instance.clue1 = false;
                break;
            case 2:
                GameManager.Instance.clue2 = false;
                break;
            case 3:
                GameManager.Instance.clue3 = false;
                break;
            case 4:
                GameManager.Instance.clue4 = false;
                break;

        }

    }
}
