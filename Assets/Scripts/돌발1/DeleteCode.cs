using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCode : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "DeleteTag")
        {
            Destroy(gameObject);
            Debug.Log("����");
        }

    }
}
