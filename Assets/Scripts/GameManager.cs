using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Ʈ�� �ڷᱸ��
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
    
    
    //���� �ð�
    [SerializeField]
    public static int m_hour = 8;
    public static int m_minite = 0;
    public static int m_day = 1;

    //���� �ؽ�Ʈ�� ���� ��� �ؽ�Ʈ �����س����� �ǰڴ�
    public Node currentNode; //�����ͷ� ��������
    public string endingText;

    void Start()
    {
        //Ʈ�� ���� ��Ʈ/����1~5 �� 21�� ���.
        Node A1 = new Node { Ending = "" };
        currentNode = A1; //���簡 �ƴ϶� �ּ� ������ �ؾ��ϴµ�.

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

        //A1.Left = ref B2; �ٸ� ����� ã��
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
