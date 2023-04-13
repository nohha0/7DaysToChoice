using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeControll : MonoBehaviour
{
    public float Speed;


    Image gaugeImage;
    private float currentGaugeValue = 0.01f; // 현재 게이지 값
    private float targetGaugeValue = 0.01f;
    private float fillSpeed = 1f; // 게이지가 채워지는 속도

    bool hasAddedGaugeValue = false;  //게이지 제어벨류
    void Start()
    {
        GameObject imageObject = GameObject.Find("게이지");
        gaugeImage = imageObject.GetComponent<Image>();
        gaugeImage.fillAmount = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetGaugeValue > currentGaugeValue)
        {
            currentGaugeValue += Speed * Time.deltaTime;
        }
        if(targetGaugeValue < currentGaugeValue)
        {
            currentGaugeValue -= Speed * Time.deltaTime;
        }

        gaugeImage.fillAmount = currentGaugeValue / 100;
    }

    public void AddGauge(float Num)
    {
        targetGaugeValue += Num;
    }

}
