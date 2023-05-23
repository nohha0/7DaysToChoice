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
        // �ʱ� ��ư ����
        if (buttonChildren.Length > 0)
        {
            currentButton = buttonChildren[currentChildIndex];
            originalColor = currentButton.GetComponent<Image>().color;
            SetButtonColor(currentButton, Color.white);
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

            SetButtonColor(currentButton, originalColor);
            currentButton = buttonChildren[currentChildIndex];
            SetButtonColor(currentButton, Color.white);
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
}