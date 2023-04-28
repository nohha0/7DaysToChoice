using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public bool AddCodeStop = false;
    void Start()
    {
        AddCodeStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(AddCodeStop)
        {
            Invoke("Stopfalse", 7.5f);
        }
    }
    public void Stopfalse()
    {
        AddCodeStop = false;
    }
    public void StopTrue()
    {
        AddCodeStop = true;
        
    }
}
