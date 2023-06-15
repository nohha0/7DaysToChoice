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
        if(ItemManager.Instance.gainedRareClue.Contains(1)&&GameManager.Instance.ClearRclue1)
        {
            Chat[0].SetActive = false;
        }
    }
}
