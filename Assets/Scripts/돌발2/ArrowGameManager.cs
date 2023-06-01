using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowGameManager : MonoBehaviour
{
    public float Size;
    public Sprite[] arrowSprites; // 방향키 스프라이트 배열
    public Transform spawnPoint; // 스프라이트 생성 위치
    public float spriteSpacing = 1f; // 스프라이트 간격
    public int[] spawnCounts; // 각 번째에 생성될 스프라이트 개수 설정

    private int maxSpriteCount = 7; // 최대 스프라이트 개수
    private bool clear = true; // clear 변수

    private void Start()
    {
        if (clear)
        {
            clear = false;
            // clear가 true일 때 SpawnSprites() 메서드 실행
            for (int i = 0; i < spawnCounts.Length; i++)
            {
                SpawnSprites(spawnCounts[i]);
                
            }
            
        }
    }

    private void SpawnSprites(int spriteCount)
    {
        // 스프라이트 간격 계산
        float spriteSpacingX = spriteSpacing;

        // 전체 스프라이트 너비 계산
        float totalWidth = (spriteCount - 1) * spriteSpacingX;

        // 시작 위치 계산
        float startX = spawnPoint.position.x - totalWidth / 2f;

        for (int i = 0; i < spriteCount; i++)
        {
            float xPos = startX + i * spriteSpacingX;
            float yPos = spawnPoint.position.y;

            // 랜덤하게 스프라이트 선택
            Sprite randomSprite = arrowSprites[Random.Range(0, arrowSprites.Length)];

            // 스프라이트를 가진 게임 오브젝트 생성
            GameObject spriteObject = new GameObject("ArrowSprite");
            spriteObject.transform.position = new Vector3(xPos, yPos, 0f);
            spriteObject.transform.parent = spawnPoint;

            // 스프라이트 렌더러 컴포넌트 추가
            SpriteRenderer spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = randomSprite;

            // 스프라이트 크기 조정
            Vector3 scale = spriteObject.transform.localScale;
            float desiredSize = Size; // 원하는 크기 값
            scale.x = desiredSize;
            scale.y = desiredSize;
            spriteObject.transform.localScale = scale;
        }
    }
}