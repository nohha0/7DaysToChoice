using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseCollider : MonoBehaviour
{
    private Color originalColor;
    private Image imageComponent;
    private bool isColliding;

    private void Start()
    {
        imageComponent = GetComponentInChildren<Image>();
        originalColor = imageComponent.color;
        isColliding = false;
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, Vector2.zero);

        bool foundCollision = false;

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.CompareTag("MyObject") && hits[i].collider.gameObject == gameObject)
            {
                foundCollision = true;
                break;
            }
        }

        if (foundCollision)
        {
            if (!isColliding)
            {
                // 충돌한 오브젝트의 이미지 색상을 하얀색으로 변경
                imageComponent.color = Color.white;
                isColliding = true;
            }
        }
        else
        {
            if (isColliding)
            {
                // 충돌이 해제된 경우 원래의 색상으로 변경
                imageComponent.color = originalColor;
                isColliding = false;
            }
        }
    }
}