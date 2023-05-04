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
        Dialog.transform.GetChild(1).GetComponent<Text>().text = GameManager.Instance.VisualDialog[GameManager.Instance.VDIndex[GameManager.Instance.VDState]].Name;
        Dialog.transform.GetChild(2).GetComponent<Text>().text = GameManager.Instance.VisualDialog[GameManager.Instance.VDIndex[GameManager.Instance.VDState]].Line;
        SetFace();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (index >= GameManager.Instance.VDIndex[GameManager.Instance.VDState + 1] - GameManager.Instance.VDIndex[GameManager.Instance.VDState])
            {
                Dialog.SetActive(false);
                index = 1;
                GameManager.Instance.VDState++;
            }
            else
            {
                Dialog.transform.GetChild(1).GetComponent<Text>().text = GameManager.Instance.VisualDialog[GameManager.Instance.VDIndex[GameManager.Instance.VDState] + index].Name;
                Dialog.transform.GetChild(2).GetComponent<Text>().text = GameManager.Instance.VisualDialog[GameManager.Instance.VDIndex[GameManager.Instance.VDState] + index].Line;
                SetFace();
                index++;
            }
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            Dialog.SetActive(true);
            Dialog.transform.GetChild(1).GetComponent<Text>().text = GameManager.Instance.VisualDialog[GameManager.Instance.VDIndex[GameManager.Instance.VDState]].Name;
            Dialog.transform.GetChild(2).GetComponent<Text>().text = GameManager.Instance.VisualDialog[GameManager.Instance.VDIndex[GameManager.Instance.VDState]].Line;
            SetFace();
        }
    }

    void SetFace()
    {
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(GameManager.Instance.VisualDialog[GameManager.Instance.VDIndex[GameManager.Instance.VDState]+index].Name.Substring(0, 1));
            if (GameManager.Instance.VisualDialog[GameManager.Instance.VDIndex[GameManager.Instance.VDState] + index].Name.Substring(0, 1) == GameManager.Instance.chars[i].Substring(0, 1))
            {
                Debug.Log("¾ÆÀ×");
                Dialog.transform.GetChild(0).GetComponent<Image>().sprite = GameManager.Instance.Faces[0 + (i * 4)];

                /*
                switch (GameManager.Instance.VisualDialog[GameManager.Instance.VDIndex[GameManager.Instance.VDState] + index].Face)
                {
                    case "1":
                        Dialog.transform.GetChild(2).GetComponent<Image>().sprite = GameManager.Instance.Faces[0 + (i * 1)];
                        break;
                    case "2":
                        Dialog.transform.GetChild(2).GetComponent<Image>().sprite = GameManager.Instance.Faces[0 + (i * 2)];
                        break;
                    case "3":
                        Dialog.transform.GetChild(2).GetComponent<Image>().sprite = GameManager.Instance.Faces[0 + (i * 3)];
                        break;
                    case "4":
                        Dialog.transform.GetChild(2).GetComponent<Image>().sprite = GameManager.Instance.Faces[0 + (i * 4)];
                        break;
                }
                */
            }
        }
    }

}
