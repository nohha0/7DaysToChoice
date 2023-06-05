using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    //explore_Items, player_Items�� �ش��ϴ� ����

    public Item     item;       // ȹ���� ������
    public Image    itemImage;  // �������� �̹���
    public bool     isFill = false;     // �������� �ִ��� ���� 

    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    //���ο� ������ ���� �߰�
    public void AddItem(Item _item)
    {
        item = _item;
        itemImage.sprite = item.itemSprite;
        SetColor(1);
        isFill = true;
    }

    //�ش� ���� ����
    public void ClearSlot()
    {
        item = null;
        itemImage.sprite = null;
        SetColor(0);
        isFill = false;
    }
}
