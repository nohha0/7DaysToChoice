using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonArrow : MonoBehaviour
{
    public GameObject[] buttonChildren;
    private int currentChildIndex = 0;
    private GameObject currentButton;
    private Color originalColor;

    private void Start()
    {
        // 초기 버튼 설정
        if (buttonChildren.Length > 0)
        {
            currentButton = buttonChildren[currentChildIndex];
            originalColor = currentButton.GetComponent<Image>().color;
            SetButtonColor(currentButton, Color.white);
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

            SetButtonColor(currentButton, originalColor);
            currentButton = buttonChildren[currentChildIndex];
            SetButtonColor(currentButton, Color.white);
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
}