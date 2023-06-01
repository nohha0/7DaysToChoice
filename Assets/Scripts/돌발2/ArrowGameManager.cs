using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowGameManager : MonoBehaviour
{
    public float Size;
    public Sprite[] arrowSprites; // ����Ű ��������Ʈ �迭
    public Transform spawnPoint; // ��������Ʈ ���� ��ġ
    public float spriteSpacing = 1f; // ��������Ʈ ����
    public int[] spawnCounts; // �� ��°�� ������ ��������Ʈ ���� ����

    private int maxSpriteCount = 7; // �ִ� ��������Ʈ ����
    private bool clear = true; // clear ����

    private void Start()
    {
        if (clear)
        {
            clear = false;
            // clear�� true�� �� SpawnSprites() �޼��� ����
            for (int i = 0; i < spawnCounts.Length; i++)
            {
                SpawnSprites(spawnCounts[i]);
                
            }
            
        }
    }

    private void SpawnSprites(int spriteCount)
    {
        // ��������Ʈ ���� ���
        float spriteSpacingX = spriteSpacing;

        // ��ü ��������Ʈ �ʺ� ���
        float totalWidth = (spriteCount - 1) * spriteSpacingX;

        // ���� ��ġ ���
        float startX = spawnPoint.position.x - totalWidth / 2f;

        for (int i = 0; i < spriteCount; i++)
        {
            float xPos = startX + i * spriteSpacingX;
            float yPos = spawnPoint.position.y;

            // �����ϰ� ��������Ʈ ����
            Sprite randomSprite = arrowSprites[Random.Range(0, arrowSprites.Length)];

            // ��������Ʈ�� ���� ���� ������Ʈ ����
            GameObject spriteObject = new GameObject("ArrowSprite");
            spriteObject.transform.position = new Vector3(xPos, yPos, 0f);
            spriteObject.transform.parent = spawnPoint;

            // ��������Ʈ ������ ������Ʈ �߰�
            SpriteRenderer spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = randomSprite;

            // ��������Ʈ ũ�� ����
            Vector3 scale = spriteObject.transform.localScale;
            float desiredSize = Size; // ���ϴ� ũ�� ��
            scale.x = desiredSize;
            scale.y = desiredSize;
            spriteObject.transform.localScale = scale;
        }
    }
}