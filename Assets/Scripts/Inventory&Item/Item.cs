using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    //7개 : ID  타입  이름  희귀도  아이템설명  보유개수  조합가능여부
    public string itemID, type, name, rare, count, manufacturable;
    public string explain;
    public Sprite itemSprite;
    public bool filled = false;
    //이미지는 인스펙터창에서 직접 넣기 + 아이템매니저에서 배열로 For문 돌리기

    public Item(string _ID, string _Type, string _Name, string _Rare, string _Explain, string _Count, string _Manufacturable, Sprite _itemSprite)
    {
        itemID = _ID; 
        type = _Type; 
        name = _Name; 
        rare = _Rare; 
        explain = _Explain; 
        count = _Count; 
        manufacturable = _Manufacturable;
        itemSprite = _itemSprite;
        filled = true;
    }
}

