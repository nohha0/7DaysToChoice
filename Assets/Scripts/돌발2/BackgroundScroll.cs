using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public SpriteRenderer[] backgroundRenderers; // 배경 요소들의 SpriteRenderer 컴포넌트 배열
    public float scrollSpeed = 1f; // 스크롤 속도

    private float scrollOffset = 0f; // 배경 스크롤 오프셋

    private void Update()
    {
        // 배경 스크롤링
        scrollOffset += scrollSpeed * Time.deltaTime;

        // 배경 요소들의 텍스처 오프셋을 업데이트하여 스크롤링 효과 생성
        foreach (SpriteRenderer renderer in backgroundRenderers)
        {
            renderer.material.SetTextureOffset("_MainTex", new Vector2(scrollOffset, 0f));
        }
    }
}