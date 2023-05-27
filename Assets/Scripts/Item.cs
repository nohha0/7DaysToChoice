using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Item
{
    public string ID, Type, Name, Rare, Explain, Count, Manufacturable;
    public Sprite itemImage; //이미지는 인스펙터창에서 직접 넣기 OR 아이템매니저에서 배열로 For문 돌리기

    public Item(string _ID, string _Type, string _Name, string _Rare, string _Explain, string _Count, string _Manufacturable)
    {
        ID = _ID; Type = _Type; Name = _Name; Rare = _Rare; Explain = _Explain; Count = _Count; Manufacturable = _Manufacturable; 
        //이미지 생성자 없음
    }

    public bool Use()
    {
        return false;
    }
}

