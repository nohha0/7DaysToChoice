using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonArrow : MonoBehaviour
{
    public GameObject[] buttonChildren;
    private int currentChildIndex = 0;
    private int BackIndex = 0;
    private GameObject currentButton;

    private Sprite[] originalSprites;
    public Sprite[] changedSprites;

    private void Start()
    {
        // �ʱ� ��ư ����
        if (buttonChildren.Length > 0)
        {
            currentButton = buttonChildren[currentChildIndex];
            originalSprites = new Sprite[buttonChildren.Length];

            // ���� ��ư�� ��������Ʈ�� ����
            for (int i = 0; i < buttonChildren.Length; i++)
            {
                originalSprites[i] = buttonChildren[i].GetComponent<Image>().sprite;
            }
        }
        SetButtonSprite(currentButton, changedSprites[currentChildIndex]);
    }

    private void Update()
    {
        // �Ʒ� ����Ű�� ������ �ڽ� �ε����� ������Ű�� �ش� �ڽ��� ��ư���� �����մϴ�.
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentChildIndex++;

            if (currentChildIndex >= buttonChildren.Length)
            {
                currentChildIndex = 0;
            }

            SetButtonSprite(currentButton, originalSprites[BackIndex]);
            currentButton = buttonChildren[currentChildIndex];
            BackIndex = currentChildIndex;
            SetButtonSprite(currentButton, changedSprites[currentChildIndex]);
        }
        // ���� ����Ű�� ������ ���
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentChildIndex--;

            if (currentChildIndex < 0)
            {
                currentChildIndex = buttonChildren.Length - 1;
            }

            SetButtonSprite(currentButton, originalSprites[BackIndex]);
            currentButton = buttonChildren[currentChildIndex];
            BackIndex = currentChildIndex;
            SetButtonSprite(currentButton, changedSprites[currentChildIndex]);
        }
        // ���� Ű�� ������ ���� ��ư�� onClick �̺�Ʈ�� ȣ���մϴ�.
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Button buttonComponent = currentButton.GetComponent<Button>();
            if (buttonComponent != null)
            {
                buttonComponent.onClick.Invoke();
            }
        }
    }

    private void SetButtonSprite(GameObject button, Sprite sprite)
    {
        Image buttonImage = button.GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.sprite = sprite;
        }
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonArrow : MonoBehaviour
{
    public GameObject[] buttonChildren;
    private int currentChildIndex = 0;
    private int BackIndex = 0;
    private GameObject currentButton;
    private Color originalColor;

    private Sprite[] originalSprite;
    public Sprite[] changedSprite;

    private void Start()
    {
        // �ʱ� ��ư ����
        if (buttonChildren.Length > 0)
        {

            currentButton = buttonChildren[currentChildIndex];
            //originalColor = currentButton.GetComponent<Image>().color;
            //SetButtonColor(currentButton, Color.white);
            originalSprite = currentButton.GetComponent<Image>().sprite;



        }
    }

    private void Update()
    {
        // �Ʒ� ����Ű�� ������ �ڽ� �ε����� ������Ű�� �ش� �ڽ��� ��ư���� �����մϴ�.
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentChildIndex++;
 

            if (currentChildIndex >= buttonChildren.Length)
            {
                currentChildIndex = 0;
            }

            SetButtonColor(currentButton, originalColor);
            currentButton = buttonChildren[currentChildIndex];
            SetButtonColor(currentButton, Color.white);
        }
        //���� ����Ű�� ������ ���
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentChildIndex--;

            if (currentChildIndex < 0)
            {
                currentChildIndex = (buttonChildren.Length -1);
            }

            //SetButtonColor(currentButton, originalColor);
            SetButtonSprite(currentButton, originalSprite);
            currentButton = buttonChildren[currentChildIndex];
            //SetButtonColor(currentButton, Color.white);
            SetButtonSprite(currentButton, changedSprite[currentChildIndex]);
        }
        // ���� Ű�� ������ ���� ��ư�� onClick �̺�Ʈ�� ȣ���մϴ�.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Button buttonComponent = currentButton.GetComponent<Button>();
            if (buttonComponent != null)
            {
                buttonComponent.onClick.Invoke();
            }
        }
    }

    private void SetButtonColor(GameObject button, Color color)
    {
        Image buttonImage = button.GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.color = color;
        }
    }
    private void SetButtonSprite(GameObject button, Sprite sprite)
    {
        SpriteRenderer spriteRenderer = button.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = sprite;
        }
    }
}*/