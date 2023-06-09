using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Clue
{
    //4�� : number, ����, �̹���, ȹ�濩��
    public string clueID, line;
    public Sprite itemSprite;

    public Clue(string _clueID, string _line)
    {
        clueID = _clueID;
        line = _line;
        //itemSprite = _itemSprite;
    }
}
