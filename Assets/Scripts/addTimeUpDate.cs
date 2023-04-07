using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addTimeUpDate : MonoBehaviour
{
    public int HourUP;
    public int MinUP;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.addTime(HourUP, MinUP);
        }
    }
}
