using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public SpriteRenderer[] backgroundRenderers; // ��� ��ҵ��� SpriteRenderer ������Ʈ �迭
    public float scrollSpeed = 1f; // ��ũ�� �ӵ�

    private float scrollOffset = 0f; // ��� ��ũ�� ������

    private void Update()
    {
        // ��� ��ũ�Ѹ�
        scrollOffset += scrollSpeed * Time.deltaTime;

        // ��� ��ҵ��� �ؽ�ó �������� ������Ʈ�Ͽ� ��ũ�Ѹ� ȿ�� ����
        foreach (SpriteRenderer renderer in backgroundRenderers)
        {
            renderer.material.SetTextureOffset("_MainTex", new Vector2(scrollOffset, 0f));
        }
    }
}