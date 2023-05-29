using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//메인스토리 씬 : 일차 시간 배경 이름 표정 대사

public class VisualDialogController : MonoBehaviour
{
    public GameObject DialogUI;

    int index = 1;

    void Start()
    {
        DialogUI.SetActive(true);
        DialogUI.transform.GetChild(1).GetComponent<Text>().text = DialogManager.Instance.VisualDialog[DialogManager.Instance.VisualDialog_StartPoints[DialogManager.Instance.VDState]].name;
        DialogUI.transform.GetChild(2).GetComponent<Text>().text = DialogManager.Instance.VisualDialog[DialogManager.Instance.VisualDialog_StartPoints[DialogManager.Instance.VDState]].line;
        //SetFace();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (index >= DialogManager.Instance.VisualDialog_StartPoints[DialogManager.Instance.VDState + 1] - DialogManager.Instance.VisualDialog_StartPoints[DialogManager.Instance.VDState])
            {
                DialogUI.SetActive(false);
                index = 1;
                DialogManager.Instance.VDState++;
            }
            else
            {
                DialogUI.transform.GetChild(1).GetComponent<Text>().text = DialogManager.Instance.VisualDialog[DialogManager.Instance.VisualDialog_StartPoints[DialogManager.Instance.VDState] + index].name;
                DialogUI.transform.GetChild(2).GetComponent<Text>().text = DialogManager.Instance.VisualDialog[DialogManager.Instance.VisualDialog_StartPoints[DialogManager.Instance.VDState] + index].line;
                //SetFace();
                index++;
            }
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            DialogUI.SetActive(true);
            DialogUI.transform.GetChild(1).GetComponent<Text>().text = DialogManager.Instance.VisualDialog[DialogManager.Instance.VisualDialog_StartPoints[DialogManager.Instance.VDState]].name;
            DialogUI.transform.GetChild(2).GetComponent<Text>().text = DialogManager.Instance.VisualDialog[DialogManager.Instance.VisualDialog_StartPoints[DialogManager.Instance.VDState]].line;
            //SetFace();
        }
    }

    void SetFace()
    {
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(DialogManager.Instance.VisualDialog[DialogManager.Instance.VisualDialog_StartPoints[DialogManager.Instance.VDState]+index].name.Substring(0, 1));
            /*
            if (DialogManager.Instance.VisualDialog[DialogManager.Instance.VDIndex[DialogManager.Instance.VDState] + index].Name.Substring(0, 1) == DialogManager.Instance.chars[i].Substring(0, 1))
            {
                Debug.Log("아잉");
                //Dialog.transform.GetChild(0).GetComponent<Image>().sprite = DialogManager.Instance.Faces[0 + (i * 4)];

                
                switch (DialogManager.Instance.VisualDialog[DialogManager.Instance.VDIndex[DialogManager.Instance.VDState] + index].Face)
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
                */
        }
    }
}
