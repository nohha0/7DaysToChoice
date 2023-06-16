using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("OnDestroy", 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnDestroy()
    {
        Destroy(gameObject);
    }
}
