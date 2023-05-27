using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Item
{
    public string ID, Type, Name, Rare, Explain, Count, Manufacturable;
    public Sprite itemImage; //�̹����� �ν�����â���� ���� �ֱ� OR �����۸Ŵ������� �迭�� For�� ������

    public Item(string _ID, string _Type, string _Name, string _Rare, string _Explain, string _Count, string _Manufacturable)
    {
        ID = _ID; Type = _Type; Name = _Name; Rare = _Rare; Explain = _Explain; Count = _Count; Manufacturable = _Manufacturable; 
        //�̹��� ������ ����
    }

    public bool Use()
    {
        return false;
    }
}

