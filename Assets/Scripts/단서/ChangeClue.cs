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
            text.text = "현재 중립입니다";
        }
        if (GameManager.Instance.Inference_Location < 3)
        {
            text.text = "현재 비긴바이오연구소를 의심하고 있습니다";
        }
        if (GameManager.Instance.Inference_Location > 3)
        {
            text.text = "현재 바티바이오연구소를 의심하고 있습니다";
        }
    }
}
