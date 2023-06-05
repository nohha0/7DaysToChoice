using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGameManager : MonoBehaviour
{
    public int[] spriteCount; // ȭ�鿡 ���� ��������Ʈ ����
    public Sprite[] arrowSprites; // ����Ű ��������Ʈ �迭
    public Transform spawnPoint; // ��������Ʈ ���� ��ġ
    public float spriteSpacing = 1f; // ��������Ʈ ����
    public float spriteLifetime = 2f; // ��������Ʈ ���� �ð�

    private List<int> spriteSequence; // ��������Ʈ ������ ����ϴ� ����Ʈ
    private int currentSpriteIndex; // ���� üũ�ؾ� �� ��������Ʈ �ε���
    private bool isCheckingInput; // �Է��� üũ ������ ����


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

            // ��������Ʈ�� �ε����� spriteSequence ����Ʈ�� �߰�
            spriteSequence.Add(randomIndex);
        }

        StartCoroutine(DestroySprites(spriteLifetime));
    }



   

    private void CheckPlayerInput()
    {
        if (currentSpriteIndex >= spriteSequence.Count)
            return; // ��� ��������Ʈ�� üũ������ ����

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

                //�ʱ�ȭ
                currentSpriteIndex = 0;
                spriteSequence.Clear();
                Count++;
            }
        }
        else
        {
            Debug.Log("Failure!");
            isCheckingInput = false;

            //�ʱ�ȭ
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
        Debug.Log("������� �˸°� �Է����ּ���");
    }
}
