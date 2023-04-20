using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VisualDialogController : MonoBehaviour
{
    public GameObject Dialog;

    int index = 1;

    void Start()
    {
        Dialog.SetActive(true);
        Dialog.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.VisualDialog[GameManager.Instance.VDIndex[GameManager.Instance.VDState]].Name;
        Dialog.transform.GetChild(1).GetComponent<Text>().text = GameManager.Instance.VisualDialog[GameManager.Instance.VDIndex[GameManager.Instance.VDState]].Line;
        //Dialog.transform.GetChild(2).GetComponent<Image>().sprite = GameManager.Instance.VisualDialog[GameManager.Instance.VDIndex[GameManager.Instance.VDState]].Line;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (index >= GameManager.Instance.VDIndex[GameManager.Instance.VDState + 1] - GameManager.Instance.VDIndex[GameManager.Instance.VDState])
            {
                Dialog.SetActive(false);
                index = 1;
                GameManager.Instance.VDState++;
            }
            else
            {
                Dialog.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.VisualDialog[GameManager.Instance.VDIndex[GameManager.Instance.VDState] + index].Name;
                Dialog.transform.GetChild(1).GetComponent<Text>().text = GameManager.Instance.VisualDialog[GameManager.Instance.VDIndex[GameManager.Instance.VDState] + index].Line;
                index++;
            }
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            Dialog.SetActive(true);
            Dialog.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.VisualDialog[GameManager.Instance.VDIndex[GameManager.Instance.VDState]].Name;
            Dialog.transform.GetChild(1).GetComponent<Text>().text = GameManager.Instance.VisualDialog[GameManager.Instance.VDIndex[GameManager.Instance.VDState]].Line;
        }
    }
}
