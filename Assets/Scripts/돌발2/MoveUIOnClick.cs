using UnityEngine;

public class MoveUIOnClick : MonoBehaviour
{
    private RectTransform uiRectTransform; // UI ������Ʈ�� RectTransform ������Ʈ

    private void Start()
    {
        uiRectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // ���콺 Ŭ�� �� Ŭ���� ��ġ�� ���� ��ǥ�� ��ȯ�մϴ�.
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // UI ������Ʈ�� ��ġ�� Ŭ���� ���� ��ǥ�� �̵���ŵ�ϴ�.
            uiRectTransform.position = worldPosition;
        }
    }
}