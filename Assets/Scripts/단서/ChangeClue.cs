using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeClue : MonoBehaviour
{
    public Text text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.Inference_Location == 3)
        {
            text.text = "���� �߸��Դϴ�";
        }
        if (GameManager.Instance.Inference_Location < 3)
        {
            text.text = "���� �����̿������Ҹ� �ǽ��ϰ� �ֽ��ϴ�";
        }
        if (GameManager.Instance.Inference_Location > 3)
        {
            text.text = "���� ��Ƽ���̿������Ҹ� �ǽ��ϰ� �ֽ��ϴ�";
        }
    }
}
