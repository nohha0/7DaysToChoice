using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    //7�� : ID  Ÿ��  �̸�  ��͵�  �����ۼ���  ��������  ���հ��ɿ���
    public string itemID, type, name, rare, count, manufacturable;
    public string explain;
    public Sprite itemSprite;
    public bool filled = false;
    //�̹����� �ν�����â���� ���� �ֱ� + �����۸Ŵ������� �迭�� For�� ������

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

