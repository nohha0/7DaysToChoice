using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIColliderActivefalse : MonoBehaviour
{
    public GameObject targetObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // UI 요소를 클릭한 경우에는 동작하지 않음
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            targetObject.SetActive(false);
        }
    }
}