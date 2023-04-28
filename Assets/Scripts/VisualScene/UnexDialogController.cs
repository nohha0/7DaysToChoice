using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UnexDialogController : MonoBehaviour
{
    public GameObject Dialog;

    int index = 0;

    void Start()
    {
        Dialog.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (index >= GameManager.Instance.UDIndex[GameManager.Instance.UDState + 1] - GameManager.Instance.UDIndex[GameManager.Instance.UDState])
            {
                Dialog.SetActive(false);
                index = 1;
                GameManager.Instance.UDState++;

                SceneManager.LoadScene(3);
            }
            else
            {
                Dialog.transform.GetChild(1).GetComponent<Text>().text = GameManager.Instance.UnexpectedDialog[GameManager.Instance.UDIndex[GameManager.Instance.UDState] + index].Name;
                Dialog.transform.GetChild(2).GetComponent<Text>().text = GameManager.Instance.UnexpectedDialog[GameManager.Instance.UDIndex[GameManager.Instance.UDState] + index].Line;
                SetFace();
                index++;
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Dialog.SetActive(true);
            Dialog.transform.GetChild(1).GetComponent<Text>().text = GameManager.Instance.UnexpectedDialog[GameManager.Instance.UDIndex[GameManager.Instance.UDState]].Name;
            Dialog.transform.GetChild(2).GetComponent<Text>().text = GameManager.Instance.UnexpectedDialog[GameManager.Instance.UDIndex[GameManager.Instance.UDState]].Line;
            SetFace();
        }
    }

    void SetFace()
    {
        for (int i = 0; i < 4; i++)
        {
            if (GameManager.Instance.UnexpectedDialog[GameManager.Instance.UDIndex[GameManager.Instance.UDState] + index].Name.Substring(0, 1) == GameManager.Instance.chars[i].Substring(0, 1))
            {
                Dialog.transform.GetChild(0).GetComponent<Image>().sprite = GameManager.Instance.Faces[0 + (i * 4)];

                /*
                switch (GameManager.Instance.UnexpectedDialog[GameManager.Instance.UDIndex[GameManager.Instance.UDState] + index].Face)
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
