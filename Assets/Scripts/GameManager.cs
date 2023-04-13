using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//트리 자료구조
public class Node
{
    public int id;
    public string Ending;
    public Node Left;
    public Node Right;
}

[System.Serializable]
public class Dialog
{
    public Dialog(string _Event, string _Day, string _Name, string _Face, string _Line)
    { Event = _Event; Day = _Day; Name = _Name; Face = _Face; Line = _Line; }

    public string Event, Day, Name, Face, Line;
}

[System.Serializable]
public class Item
{
    public Item(string _ID, string _Type, string _Name, string _Rare, string _Explain, string _Count, 
        string _C_Material, string _Material_1, string _Material_2, string _Material_3, string _Material_4)
    { ID=_ID; Type= _Type; Name= _Name; Rare= _Rare; Explain = _Explain; Count = _Count;
        C_Material = _C_Material; Material_1 = _Material_1; Material_2 = _Material_2; Material_3 = _Material_3; Material_4 = _Material_4; }
    public string ID, Type, Name, Rare, Explain, Count, C_Material, Material_1, Material_2, Material_3, Material_4;
}

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    //캐릭터 목록
    Character Jung_Yoonwoo = new MainCharacter("정윤우");
    Character Shin_Seri = new Fellow("신세리");
    Character Yoo_Hwaseul = new Fellow("유화설");
    Character Seo_Shinpyeong = new Fellow("서신평");

    [SerializeField]
    public List<Character> characters;

    //아이템 목록
    public TextAsset ItemFile;
    public List<Item> ItemList;

    //대사
    public TextAsset DialogFile;
    public List<Dialog> Day1Dialogs;

    //게임 시계
    [SerializeField]
    public static int m_hour = 8;
    public static int m_minite = 0;
    public static int m_day = 1;

    //트리 진행사항
    public static Node currentNode;

    void Start()
    {
        MakeTree();

        characters.Add(Jung_Yoonwoo);
        characters.Add(Shin_Seri);
        characters.Add(Yoo_Hwaseul);
        characters.Add(Seo_Shinpyeong);

        string[] item_Rows = ItemFile.text.Substring(0, ItemFile.text.Length - 1).Split('\n');
        for (int i = 0; i < item_Rows.Length; i++)
        {
            string[] row = item_Rows[i].Split('\t');

            ItemList.Add(new Item(row[0], row[1], row[2], row[3], row[4], row[5], row[6],
                row[7], row[8], row[9], row[10]));
        }

        string[] dialog_Rows = DialogFile.text.Substring(0, DialogFile.text.Length - 1).Split('\n');
        for (int i = 0; i < dialog_Rows.Length; i++)
        {
            string[] row = dialog_Rows[i].Split('\t');

            Day1Dialogs.Add(new Dialog(row[0], row[1], row[2], row[3], row[4]));
        }
    }

    void MakeTree()
    {
        //트리 생성 루트/레벨1~5 총 21개 노드.
        Node A1 = new Node { id = 1, Ending = "중립" };
        currentNode = A1;

        Node B2 = new Node { id = 2, Ending = "해피엔딩" };
        Node B3 = new Node { id = 3, Ending = "배드엔딩" };

        Node C4 = new Node { id = 4, Ending = "해피엔딩" };
        Node C5 = new Node { id = 5, Ending = "중립" };
        Node C6 = new Node { id = 6, Ending = "배드엔딩" };

        Node D7 = new Node { id = 7, Ending = "해피엔딩" };
        Node D8 = new Node { id = 8, Ending = "해피엔딩" };
        Node D9 = new Node { id = 9, Ending = "배드엔딩" };
        Node D10 = new Node { id = 10, Ending = "배드엔딩" };

        Node E11 = new Node { id = 11, Ending = "해피엔딩" };
        Node E12 = new Node { id = 12, Ending = "해피엔딩" };
        Node E13 = new Node { id = 13, Ending = "중립" };
        Node E14 = new Node { id = 14, Ending = "배드엔딩" };
        Node E15 = new Node { id = 15, Ending = "배드엔딩" };

        Node F16 = new Node { id = 16, Ending = "해피엔딩" };
        Node F17 = new Node { id = 17, Ending = "해피엔딩" };
        Node F18 = new Node { id = 18, Ending = "해피엔딩" };
        Node F19 = new Node { id = 19, Ending = "배드엔딩" };
        Node F20 = new Node { id = 20, Ending = "배드엔딩" };
        Node F21 = new Node { id = 21, Ending = "배드엔딩" };

        A1.Left = B2;
        A1.Right = B3;

        B2.Left = C4;
        B2.Right = C5;
        B3.Left = C5;
        B3.Right = C6;

        C4.Left = D7;
        C4.Right = D8;
        C5.Left = D8;
        C5.Right = D9;
        C6.Left = D9;
        C6.Right = D10;

        D7.Left = E11;
        D7.Right = E12;
        D8.Left = E12;
        D8.Right = E13;
        D9.Left = E13;
        D9.Right = E14;
        D10.Left = E14;
        D10.Right = E15;

        E11.Left = F16;
        E11.Right = F17;
        E12.Left = F17;
        E12.Right = F18;
        E13.Left = F18;
        E13.Right = F19;
        E14.Left = F19;
        E14.Right = F20;
        E15.Left = F20;
        E15.Right = F21;
    }

    void Update()
    {
        TimeUpdate();
    }

    void TimeUpdate() //시간 업데이트
    {
        if (m_hour >= 24)
        {
            m_hour = 0;
            m_day++;
        }
        if (m_minite >= 60) //시간 증가
        {
            m_minite = 0;
            m_hour++;
        }
    }

    public void AddTime(int hour, int minite)
    {
        m_hour += hour;
        m_minite += minite;
    }
}
