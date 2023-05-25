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
        // 초기 버튼 설정
        if (buttonChildren.Length > 0)
        {
            currentButton = buttonChildren[currentChildIndex];
            originalSprites = new Sprite[buttonChildren.Length];

            // 현재 버튼의 스프라이트를 저장
            for (int i = 0; i < buttonChildren.Length; i++)
            {
                originalSprites[i] = buttonChildren[i].GetComponent<Image>().sprite;
            }
        }
        SetButtonSprite(currentButton, changedSprites[currentChildIndex]);
    }

    private void Update()
    {
        // 아래 방향키를 누르면 자식 인덱스를 증가시키고 해당 자식을 버튼으로 설정합니다.
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
        // 위쪽 방향키를 눌렀을 경우
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
        // 엔터 키를 누르면 현재 버튼의 onClick 이벤트를 호출합니다.
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
        // 초기 버튼 설정
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
        // 아래 방향키를 누르면 자식 인덱스를 증가시키고 해당 자식을 버튼으로 설정합니다.
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
        //위쪽 방향키를 눌렀을 경우
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
        // 엔터 키를 누르면 현재 버튼의 onClick 이벤트를 호출합니다.
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