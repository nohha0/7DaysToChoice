using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using System;
using System.Collections.Generic;
using System.IO;

//트리 자료구조
public class Node
{
    public int id;
    public string Ending;
    public Node Left;
    public Node Right;
}

//저장 데이터 구조
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



    
    //캐릭터들 스텟 관리
    public Character Jung_Yoonwoo = new Character("정윤우", 100, 100, 50, 20, 30, 0);
    public Character Shin_Seri = new Character("신세리", 100, 100, 50, 20, 0, 10);
    public Character Yoo_Hwaseul = new Character("유화설", 100, 100, 50, 20, 0, 10);
    public Character Seo_Shinpyeong = new Character("서신평", 100, 100, 50, 20, 0, 10);

    //게임 시계   
    [SerializeField] 
    public static int m_hour = 8;
    public static int m_minite = 0;
    public static int m_day = 1;


    //사망 캐릭터
    public static bool Jung_YoonwooLife = true;
    public static bool Shin_SeriLife = true;
    public static bool Yoo_HwaseulLife = true;
    public static bool Seo_ShinpyeongLife = true;


    //트리 진행사항
    public static Node currentNode;




    //돌발1
    public bool AddCodeStop = false;

    //돌발 2
    public static bool isCheakLound = false;
    public static int Heart = 2;         // 목숨
    public static float distance;   // 거리



    // JSON 파일 경로
    public string jsonFilePath = "gameData.json";    //빌드 할 경우 생김


    //public string jsonFilePath;    //테스트 파일

    void Start()
    {

        //jsonFilePath = Path.Combine(Application.persistentDataPath, "gameData.json");  //테스트

        // 데이터를 JSON 파일로 저장
        SaveGameData();
        LoadGameData();

        AddCodeStop = false;
        MakeTree();
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

    void TimeUpdate() //시간 업데이트
    {
        if (m_minite >= 60) //시간 증가
        {
            m_minite = 0;
            m_hour++;
        }

        if (m_hour >= 24) //시간 증가
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

        Debug.Log($"{hour}시간 증가해서 {m_hour}시");
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



    // 데이터 세이브
    public void SaveGameData()
    {
        // 캐릭터 데이터 리스트 생성
        List<Character> characters = new List<Character>()
        {
            Jung_Yoonwoo,
            Shin_Seri,
            Yoo_Hwaseul,
            Seo_Shinpyeong
        };

        // 게임 데이터 객체 생성
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

        // 게임 데이터를 JSON으로 변환
        string jsonData = JsonUtility.ToJson(gameData, true);

        // JSON 파일에 저장
        File.WriteAllText(jsonFilePath, jsonData);

        Debug.Log("게임이 저장됨");
    }


    //데이터 불러오기
    public void LoadGameData()
    {
        if (File.Exists(jsonFilePath))
        {
            // JSON 파일에서 데이터 읽어오기
            string jsonData = File.ReadAllText(jsonFilePath);

            // JSON을 게임 데이터 객체로 변환
            GameData gameData = JsonUtility.FromJson<GameData>(jsonData);

            // 캐릭터 데이터 복원
            Jung_Yoonwoo = gameData.characters[0];
            Shin_Seri = gameData.characters[1];
            Yoo_Hwaseul = gameData.characters[2];
            Seo_Shinpyeong = gameData.characters[3];

            // 노드 데이터 복원
            currentNode = gameData.currentNode;

            // 시간 데이터 복원
            m_hour = gameData.m_hour;
            m_minite = gameData.m_minite;
            m_day = gameData.m_day;

            // 사망 캐릭터 데이터 복원
            Jung_YoonwooLife = gameData.Jung_YoonwooLife;
            Shin_SeriLife = gameData.Shin_SeriLife;
            Yoo_HwaseulLife = gameData.Yoo_HwaseulLife;
            Seo_ShinpyeongLife = gameData.Seo_ShinpyeongLife;

            Debug.Log("데이터를 불러옴.");
        }
        else
        {
            Debug.Log("데이터를 찾아올수 없음");
        }
    }

}
