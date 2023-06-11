using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using System;
using System.Collections.Generic;
using System.IO;

//Ʈ�� �ڷᱸ��
public class Node
{
    public int id;
    public string Ending;
    public Node Left;
    public Node Right;
}

//���� ������ ����
[Serializable]
public class GameData
{
    public List<Character> characters;
    public Node currentNode;
    public int m_hour;
    public int m_minite;
    public int m_day;
    public bool Jung_YoonwooLife;
    public bool Shin_SeriLife;
    public bool Yoo_HwaseulLife;
    public bool Seo_ShinpyeongLife;
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



    
    //ĳ���͵� ���� ����
    public Character Jung_Yoonwoo = new Character("������", 100, 100, 50, 20, 30, 0);
    public Character Shin_Seri = new Character("�ż���", 100, 100, 50, 20, 0, 10);
    public Character Yoo_Hwaseul = new Character("��ȭ��", 100, 100, 50, 20, 0, 10);
    public Character Seo_Shinpyeong = new Character("������", 100, 100, 50, 20, 0, 10);

    //���� �ð�   
    [SerializeField] 
    public static int m_hour = 8;
    public static int m_minite = 0;
    public static int m_day = 1;


    //��� ĳ����
    public static bool Jung_YoonwooLife = true;
    public static bool Shin_SeriLife = true;
    public static bool Yoo_HwaseulLife = true;
    public static bool Seo_ShinpyeongLife = true;


    //Ʈ�� �������
    public static Node currentNode;




    //����1
    public bool AddCodeStop = false;

    //���� 2
    public static bool isCheakLound = false;
    public static int Heart = 2;         // ���
    public static float distance;   // �Ÿ�



    // JSON ���� ���
    public string jsonFilePath = "gameData.json";    //���� �� ��� ����


    //public string jsonFilePath;    //�׽�Ʈ ����

    void Start()
    {

        //jsonFilePath = Path.Combine(Application.persistentDataPath, "gameData.json");  //�׽�Ʈ

        // �����͸� JSON ���Ϸ� ����
        SaveGameData();
        LoadGameData();

        AddCodeStop = false;
        MakeTree();
    }

    void MakeTree()
    {
        //Ʈ�� ���� ��Ʈ/����1~5 �� 21�� ���.
        Node A1 = new Node { id = 1, Ending = "�߸�" };
        currentNode = A1;

        Node B2 = new Node { id = 2, Ending = "���ǿ���" };
        Node B3 = new Node { id = 3, Ending = "��忣��" };

        Node C4 = new Node { id = 4, Ending = "���ǿ���" };
        Node C5 = new Node { id = 5, Ending = "�߸�" };
        Node C6 = new Node { id = 6, Ending = "��忣��" };

        Node D7 = new Node { id = 7, Ending = "���ǿ���" };
        Node D8 = new Node { id = 8, Ending = "���ǿ���" };
        Node D9 = new Node { id = 9, Ending = "��忣��" };
        Node D10 = new Node { id = 10, Ending = "��忣��" };

        Node E11 = new Node { id = 11, Ending = "���ǿ���" };
        Node E12 = new Node { id = 12, Ending = "���ǿ���" };
        Node E13 = new Node { id = 13, Ending = "�߸�" };
        Node E14 = new Node { id = 14, Ending = "��忣��" };
        Node E15 = new Node { id = 15, Ending = "��忣��" };

        Node F16 = new Node { id = 16, Ending = "���ǿ���" };
        Node F17 = new Node { id = 17, Ending = "���ǿ���" };
        Node F18 = new Node { id = 18, Ending = "���ǿ���" };
        Node F19 = new Node { id = 19, Ending = "��忣��" };
        Node F20 = new Node { id = 20, Ending = "��忣��" };
        Node F21 = new Node { id = 21, Ending = "��忣��" };

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
        if(Jung_Yoonwoo.healthPoint <= 0 || Jung_Yoonwoo.stress >= 100)
        {
            if (SceneManager.GetActiveScene().name == "Ending") return;
            SceneManager.LoadScene("Ending");
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        TimeUpdate();

        if (AddCodeStop)
        {
            Invoke("Stopfalse", 7.5f);
        }
    }

    void TimeUpdate() //�ð� ������Ʈ
    {
        if (m_minite >= 60) //�ð� ����
        {
            m_minite = 0;
            m_hour++;
        }

        if (m_hour >= 24) //�ð� ����
        {
            m_hour = 0;
            m_day++;
        }
    }

    public void AddTimeHour(int hour)
    {
        m_hour += hour;

        GameManager.Instance.Jung_Yoonwoo.hunger -= 10;
        GameManager.Instance.Seo_Shinpyeong.hunger -= 10;
        GameManager.Instance.Shin_Seri.hunger -= 10;
        GameManager.Instance.Yoo_Hwaseul.hunger -= 10;

        Debug.Log($"{hour}�ð� �����ؼ� {m_hour}��");
    }

    public void AddTimeMinite(int minite)
    {
        m_minite += minite;
    }

    public void Stopfalse()
    {
        AddCodeStop = false;
    }

    public void StopTrue()
    {
        AddCodeStop = true;
    }

    public void CallNightStory()
    {
    }

    public void CallMorningStory()
    {
    }



    // ������ ���̺�
    public void SaveGameData()
    {
        // ĳ���� ������ ����Ʈ ����
        List<Character> characters = new List<Character>()
        {
            Jung_Yoonwoo,
            Shin_Seri,
            Yoo_Hwaseul,
            Seo_Shinpyeong
        };

        // ���� ������ ��ü ����
        GameData gameData = new GameData()
        {
            characters = characters,
            currentNode = currentNode,
            m_hour = m_hour,
            m_minite = m_minite,
            m_day = m_day,
            Jung_YoonwooLife = Jung_YoonwooLife,
            Shin_SeriLife = Shin_SeriLife,
            Yoo_HwaseulLife = Yoo_HwaseulLife,
            Seo_ShinpyeongLife = Seo_ShinpyeongLife
        };

        // ���� �����͸� JSON���� ��ȯ
        string jsonData = JsonUtility.ToJson(gameData, true);

        // JSON ���Ͽ� ����
        File.WriteAllText(jsonFilePath, jsonData);

        Debug.Log("������ �����");
    }


    //������ �ҷ�����
    public void LoadGameData()
    {
        if (File.Exists(jsonFilePath))
        {
            // JSON ���Ͽ��� ������ �о����
            string jsonData = File.ReadAllText(jsonFilePath);

            // JSON�� ���� ������ ��ü�� ��ȯ
            GameData gameData = JsonUtility.FromJson<GameData>(jsonData);

            // ĳ���� ������ ����
            Jung_Yoonwoo = gameData.characters[0];
            Shin_Seri = gameData.characters[1];
            Yoo_Hwaseul = gameData.characters[2];
            Seo_Shinpyeong = gameData.characters[3];

            // ��� ������ ����
            currentNode = gameData.currentNode;

            // �ð� ������ ����
            m_hour = gameData.m_hour;
            m_minite = gameData.m_minite;
            m_day = gameData.m_day;

            // ��� ĳ���� ������ ����
            Jung_YoonwooLife = gameData.Jung_YoonwooLife;
            Shin_SeriLife = gameData.Shin_SeriLife;
            Yoo_HwaseulLife = gameData.Yoo_HwaseulLife;
            Seo_ShinpyeongLife = gameData.Seo_ShinpyeongLife;

            Debug.Log("�����͸� �ҷ���.");
        }
        else
        {
            Debug.Log("�����͸� ã�ƿü� ����");
        }
    }

}
