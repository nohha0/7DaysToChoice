using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGameManager : MonoBehaviour
{
    public int[] spriteCount; // 화면에 나올 스프라이트 개수
    public Sprite[] arrowSprites; // 방향키 스프라이트 배열
    public Transform spawnPoint; // 스프라이트 생성 위치
    public float spriteSpacing = 1f; // 스프라이트 간격
    public float spriteLifetime = 2f; // 스프라이트 유지 시간

    private List<int> spriteSequence; // 스프라이트 순서를 기억하는 리스트
    private int currentSpriteIndex; // 현재 체크해야 할 스프라이트 인덱스
    private bool isCheckingInput; // 입력을 체크 중인지 여부


    private int Count = 0;
    private void Start()
    {
        spriteSequence = new List<int>();
    }
    private void Update()
    {

        if(GameManager.isCheakLound)
        {
            SpawnSprites(spriteCount[Count]);
        }



        if (isCheckingInput)
        {
            CheckPlayerInput();
        }
    }


    private void SpawnSprites(int count)
    {
        float totalWidth = (count - 1) * spriteSpacing;
        float startX = spawnPoint.position.x - totalWidth / 2f;

        for (int i = 0; i < count; i++)
        {
            float xPos = startX + i * spriteSpacing;
            float yPos = spawnPoint.position.y;

            int randomIndex = Random.Range(0, arrowSprites.Length);
            Sprite randomSprite = arrowSprites[randomIndex];

            GameObject spriteObject = new GameObject("ArrowSprite");
            spriteObject.transform.position = new Vector3(xPos, yPos, 0f);
            spriteObject.transform.parent = spawnPoint;

            SpriteRenderer spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = randomSprite;

            // 스프라이트의 인덱스를 spriteSequence 리스트에 추가
            spriteSequence.Add(randomIndex);
        }

        StartCoroutine(DestroySprites(spriteLifetime));
    }



   

    private void CheckPlayerInput()
    {
        if (currentSpriteIndex >= spriteSequence.Count)
            return; // 모든 스프라이트를 체크했으면 종료

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Left");
            CheckInputMatch(0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up");
            CheckInputMatch(1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down");
            CheckInputMatch(2);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Right");
            CheckInputMatch(3);
        }
    }

    private void CheckInputMatch(int expectedInput)
    {
        int spriteIndex = spriteSequence[currentSpriteIndex];

        if (expectedInput == spriteIndex)
        {
            currentSpriteIndex++;

            if (currentSpriteIndex >= spriteSequence.Count)
            {
                Debug.Log("Success!");
                isCheckingInput = false;

                //초기화
                currentSpriteIndex = 0;
                spriteSequence.Clear();
                Count++;
            }
        }
        else
        {
            Debug.Log("Failure!");
            isCheckingInput = false;

            //초기화
            currentSpriteIndex = 0;
            spriteSequence.Clear();
            Count++;
        }
    }

    private IEnumerator DestroySprites(float delay)
    {
        yield return new WaitForSeconds(delay);

        foreach (Transform child in spawnPoint)
        {
            child.gameObject.SetActive(false);
        }
        isCheckingInput = true;
        currentSpriteIndex = 0;
        Debug.Log("순서대로 알맞게 입력해주세요");
    }
}
