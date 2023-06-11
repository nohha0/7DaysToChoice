using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIColliderActivefalse : MonoBehaviour
{
    public GameObject targetObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out hit) || hit.collider.gameObject != targetObject)
            {
                targetObject.SetActive(false);
            }
        }
    }
}