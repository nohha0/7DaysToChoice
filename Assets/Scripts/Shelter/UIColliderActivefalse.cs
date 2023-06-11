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
            // UI ��Ҹ� Ŭ���� ��쿡�� �������� ����
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            targetObject.SetActive(false);
        }
    }
}