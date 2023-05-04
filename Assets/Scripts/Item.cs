using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Item
{
    public string ID, Type, Name, Rare, Explain, Count, 
        C_Material, Material_1, Material_2, Material_3, Material_4;
    public Sprite itemImage;

    public Item(string _ID, string _Type, string _Name, string _Rare, string _Explain, string _Count,
        string _C_Material, string _Material_1, string _Material_2, string _Material_3, string _Material_4)
    {
        ID = _ID; Type = _Type; Name = _Name; Rare = _Rare; Explain = _Explain; Count = _Count;
        //이미지 생성자 없음
        C_Material = _C_Material; Material_1 = _Material_1; Material_2 = _Material_2; Material_3 = _Material_3; Material_4 = _Material_4;
    }

    public bool Use()
    {
        return false;
    }
}

