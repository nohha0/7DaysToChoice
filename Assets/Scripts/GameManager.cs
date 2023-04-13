using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//트리 자료구조
public class Node
{
    public string Ending;
    public Node Left;
    public Node Right;
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
    
    
    //게임 시계
    [SerializeField]
    public static int m_hour = 8;
    public static int m_minite = 0;
    public static int m_day = 1;

    //엔딩 텍스트에 현재 노드 텍스트 저장해놓으면 되겠다
    public Node currentNode; //포인터로 만들어야함
    public string endingText;

    void Start()
    {
        //트리 생성 루트/레벨1~5 총 21개 노드.
        Node A1 = new Node { Ending = "" };
        currentNode = A1; //복사가 아니라 주소 참조를 해야하는데.

        Node B2 = new Node { Ending = "" };
        Node B3 = new Node { Ending = "" };

        Node C4 = new Node { Ending = "" };
        Node C5 = new Node { Ending = "" };
        Node C6 = new Node { Ending = "" };

        Node D7 = new Node { Ending = "" };
        Node D8 = new Node { Ending = "" };
        Node D9 = new Node { Ending = "" };
        Node D10 = new Node { Ending = "" };

        Node E11 = new Node { Ending = "" };
        Node E12 = new Node { Ending = "" };
        Node E13 = new Node { Ending = "" };
        Node E14 = new Node { Ending = "" };
        Node E15 = new Node { Ending = "" };

        Node F16 = new Node { Ending = "" };
        Node F17 = new Node { Ending = "" };
        Node F18 = new Node { Ending = "" };
        Node F19 = new Node { Ending = "" };
        Node F20 = new Node { Ending = "" };
        Node F21 = new Node { Ending = "" };

        //A1.Left = ref B2; 다른 방법을 찾자
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
