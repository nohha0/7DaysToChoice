using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    //explore_Items, player_Items에 해당하는 슬롯

    public Item     item;       // 획득한 아이템
    public Image    itemImage;  // 아이템의 이미지
    public bool     isFill = false;     // 아이템이 있는지 여부 

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
    }

    //해당 슬롯 삭제
    public void ClearSlot()
    {
        item = null;
        itemImage.sprite = null;
        SetColor(0);
        isFill = false;
    }
}
