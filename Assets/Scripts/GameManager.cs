using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Ʈ�� �ڷᱸ��
public class Node
{
    public int id;
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
    

    //���� �ð�
    [SerializeField]
    public static int m_hour = 8;
    public static int m_minite = 0;
    public static int m_day = 1;

    public static Node currentNode;

    void Start()
    {
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
        TimeUpdate();
    }

    void TimeUpdate() //�ð� ������Ʈ
    {
        if (m_hour >= 24)
        {
            m_hour = 0;
            m_day++;
        }
        if (m_minite >= 60) //�ð� ����
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
