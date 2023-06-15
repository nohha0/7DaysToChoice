using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowGameManager : MonoBehaviour
{

    public GameObject ArrowGame;
    public GameObject HeartGame;

    public int[] spriteCount; // ȭ�鿡 ���� ��������Ʈ ����
    public Sprite[] arrowSprites; // ����Ű ��������Ʈ �迭
    public Transform spawnPoint; // ��������Ʈ ���� ��ġ
    public float spriteSpacing = 1f; // ��������Ʈ ����
    public float spriteLifetime = 2f; // ��������Ʈ ���� �ð�
    public Vector3 spriteScale = Vector3.one; // ��������Ʈ ũ��

    public Text instructionText; // UI �ؽ�Ʈ ������Ʈ

    private List<int> spriteSequence; // ��������Ʈ ������ ����ϴ� ����Ʈ
    private int currentSpriteIndex; // ���� üũ�ؾ� �� ��������Ʈ �ε���
    private bool isCheckingInput; // �Է��� üũ ������ ����

    private int count = 0;
    private bool hasSpawnedSprites; // ��������Ʈ�� �����ߴ��� ����

    public Image gaugeImage; // �������� ǥ���� �̹���
    private float currentFill = 0f; // ���� �������� ä�� ����

    private void Start()
    {
        spriteSequence = new List<int>();


        // �������� �ʱ� ���� �ʷ� ������ �����մϴ�.
        currentFill = 1;

        // ������ �̹����� �ʱ� ���� �ݿ��մϴ�.
        gaugeImage.fillAmount = currentFill;
    }

    private void Update()
    {
        if (GameManager.isCheakLound && !hasSpawnedSprites)
        {
            SpawnSprites(spriteCount[count]);
            hasSpawnedSprites = true;
        }

        if (isCheckingInput)
        {
            CheckPlayerInput();
        }

        currentFill -= Time.deltaTime / spriteLifetime;

        if (currentFill <= 0)
        {
            currentFill = 0;
            // �߰�����: �������� ������ �پ����� ���� ó��
            // ���⿡ �ʿ��� ������ �߰��ϼ���.
        }

        gaugeImage.fillAmount = currentFill;
    }

    private void SpawnSprites(int count)
    {
        float totalWidth = (count - 1) * spriteSpacing;
        float startX = spawnPoint.localPosition.x - totalWidth / 2f;

        for (int i = 0; i < count; i++)
        {
            float xPos = startX + i * spriteSpacing;
            float yPos = spawnPoint.localPosition.y;

            int randomIndex = Random.Range(0, arrowSprites.Length);
            Sprite randomSprite = arrowSprites[randomIndex];

            GameObject spriteObject = new GameObject("ArrowSprite", typeof(Image));
            spriteObject.transform.SetParent(spawnPoint, false);
            spriteObject.transform.localPosition = new Vector3(xPos, yPos, 0f);
            spriteObject.transform.localScale = spriteScale;

            Image spriteRenderer = spriteObject.GetComponent<Image>();
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
                Debug.Log("����");
                isCheckingInput = false;

                ArrowGame.SetActive(false);
                HeartGame.SetActive(true);
                GameManager.distance = 70;

                // �ʱ�ȭ
                currentFill = 1;
                currentSpriteIndex = 0;
                spriteSequence.Clear();
                count++;
                hasSpawnedSprites = false;

                // ��� ��������Ʈ Ŭ���� ��
                if (count >= spriteCount.Length)
                {
                    instructionText.text = "��� ��������Ʈ Ŭ����!";
                    return;
                }
            }
        }
        else
        {
            Debug.Log("����");
            isCheckingInput = false;

            // �ʱ�ȭ
            currentSpriteIndex = 0;
            spriteSequence.Clear();
            hasSpawnedSprites = false;
        }
    }

    private IEnumerator DestroySprites(float delay)
    {
        yield return new WaitForSeconds(delay);

        foreach (Transform child in spawnPoint)
        {
            Destroy(child.gameObject);
        }

        isCheckingInput = true;
        currentSpriteIndex = 0;

        instructionText.text = "������� �˸°� �Է����ּ���";
    }
}


���� ��ũ��Ʈ����

private void CheckInputMatch(int expectedInput)
{
    int spriteIndex = spriteSequence[currentSpriteIndex];

    if (expectedInput == spriteIndex)
    {
        currentSpriteIndex++;

        if (currentSpriteIndex >= spriteSequence.Count)
        {
            Debug.Log("����");
            isCheckingInput = false;

            ArrowGame.SetActive(false);
            HeartGame.SetActive(true);
            GameManager.distance = 70;

            // �ʱ�ȭ
            currentFill = 1;
            currentSpriteIndex = 0;
            spriteSequence.Clear();
            count++;
            hasSpawnedSprites = false;

            // ��� ��������Ʈ Ŭ���� ��
            if (count >= spriteCount.Length)
            {
                instructionText.text = "��� ��������Ʈ Ŭ����!";
                return;
            }
        }
    }
    else
    {
        Debug.Log("����");
        isCheckingInput = false;

        // �ʱ�ȭ
        currentSpriteIndex = 0;
        spriteSequence.Clear();
        hasSpawnedSprites = false;
    }
}