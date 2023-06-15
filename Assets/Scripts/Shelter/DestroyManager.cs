using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    public float DeleteTime; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf)
        {
            Invoke("OnDestroy", DeleteTime);
        }
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
