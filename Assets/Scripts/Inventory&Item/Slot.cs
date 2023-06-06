using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler 나중에 쓸 일이 있나?

    //explore_Items, player_Items에 해당하는 슬롯

    public int      slotIndex;
    public Item     item;                // 획득한 아이템
    public Image    itemImage;           // 아이템의 이미지
    public bool     isFill = false;      // 아이템이 있는지 여부 

    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    //새로운 아이템 슬롯 추가
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

    //해당 슬롯 삭제
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
        //식량으로 스텟 올리기.
        
        ClearSlot();
    }

    // 마우스 커서가 슬롯에 들어갈 때 발동
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item.filled)
            ItemManager.Instance.ShowToolTip(item, transform.position);
    }

    // 마우스 커서가 슬롯에서 나올 때 발동
    public void OnPointerExit(PointerEventData eventData)
    {
        ItemManager.Instance.HideToolTip();
    }
}
