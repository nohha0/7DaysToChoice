using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler ���߿� �� ���� �ֳ�?

    //explore_Items, player_Items�� �ش��ϴ� ����

    public int      slotIndex;
    public Item     item;                // ȹ���� ������
    public Image    itemImage;           // �������� �̹���
    public bool     isFill = false;      // �������� �ִ��� ���� 

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

        if (SceneManager.GetActiveScene().name == "Exploration")
        {
            ItemManager.Instance.explore_Items[slotIndex] = _item;
        }
    }

    //�ش� ���� ����
    public void ClearSlot()
    {
        item = null;
        itemImage.sprite = null;
        SetColor(0);
        isFill = false;

        if(SceneManager.GetActiveScene().name == "Exploration")
        {
            ItemManager.Instance.explore_Items[slotIndex] = null;
        }
    }

    public void UseItem()
    {
        //�ķ����� ���� �ø���.
        
        ClearSlot();
    }

    // ���콺 Ŀ���� ���Կ� �� �� �ߵ�
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item.filled)
            ItemManager.Instance.ShowToolTip(item, transform.position);
    }

    // ���콺 Ŀ���� ���Կ��� ���� �� �ߵ�
    public void OnPointerExit(PointerEventData eventData)
    {
        ItemManager.Instance.HideToolTip();
    }
}
