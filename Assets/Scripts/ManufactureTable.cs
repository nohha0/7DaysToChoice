using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ManufactureTable
{
    //6�� : ID �̸�	�ʿ���ᰳ�� �ʿ� ��� 1 (ID) �ʿ� ��� 2 (ID) �ʿ� ��� 3 (ID)
    public string itemID, name, materialCount, material_1, material_2, material_3;

    public ManufactureTable(string _id, string _name, string _materialCount, string _material_1, string _material_2, string _material_3)
    {
        itemID = _id;
        name = _name;
        materialCount = _materialCount;
        material_1 = _material_1;
        material_2 = _material_2;
        material_3 = _material_3;
    }
}
