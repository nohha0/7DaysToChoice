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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (index >= DialogManager.Instance.UnexpDialog_StartPoints[DialogManager.Instance.UDState + 1] - DialogManager.Instance.UnexpDialog_StartPoints[DialogManager.Instance.UDState])
            {
                Dialog.SetActive(false);
                index = 1;
                DialogManager.Instance.UDState++;

                if (DialogManager.Instance.UDState == 3)
                {
                    Debug.Log("ddd");
                    SceneManager.LoadScene(3);
                }
            }
            else
            {
                Dialog.transform.GetChild(1).GetComponent<Text>().text = DialogManager.Instance.UnexpectedDialog[DialogManager.Instance.UnexpDialog_StartPoints[DialogManager.Instance.UDState] + index].name;
                Dialog.transform.GetChild(2).GetComponent<Text>().text = DialogManager.Instance.UnexpectedDialog[DialogManager.Instance.UnexpDialog_StartPoints[DialogManager.Instance.UDState] + index].line;
                //SetFace();
                index++;
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Dialog.SetActive(true);
            Dialog.transform.GetChild(1).GetComponent<Text>().text = DialogManager.Instance.UnexpectedDialog[DialogManager.Instance.UnexpDialog_StartPoints[DialogManager.Instance.UDState]].name;
            Dialog.transform.GetChild(2).GetComponent<Text>().text = DialogManager.Instance.UnexpectedDialog[DialogManager.Instance.UnexpDialog_StartPoints[DialogManager.Instance.UDState]].line;
            //SetFace();
        }
    }

    void SetFace()
    {
        /*
        for (int i = 0; i < 4; i++)
        {
            if (DialogManager.Instance.UnexpectedDialog[DialogManager.Instance.UDIndex[DialogManager.Instance.UDState] + index].Name.Substring(0, 1) == DialogManager.Instance.chars[i].Substring(0, 1))
            {
                //Dialog.transform.GetChild(0).GetComponent<Image>().sprite = DialogManager.Instance.Faces[0 + (i * 4)];

                
                switch (DialogManager.Instance.UnexpectedDialog[DialogManager.Instance.UDIndex[DialogManager.Instance.UDState] + index].Face)
                {
                    case "1":
                        Dialog.transform.GetChild(2).GetComponent<Image>().sprite = DialogManager.Instance.Faces[0 + (i * 1)];
                        break;
                    case "2":
                        Dialog.transform.GetChild(2).GetComponent<Image>().sprite = DialogManager.Instance.Faces[0 + (i * 2)];
                        break;
                    case "3":
                        Dialog.transform.GetChild(2).GetComponent<Image>().sprite = DialogManager.Instance.Faces[0 + (i * 3)];
                        break;
                    case "4":
                        Dialog.transform.GetChild(2).GetComponent<Image>().sprite = DialogManager.Instance.Faces[0 + (i * 4)];
                        break;
                }
                
             }
         }
        */
    }
}
