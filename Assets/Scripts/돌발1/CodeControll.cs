using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeControll : MonoBehaviour
{
    public GameObject Greencode; //�۾� Ȱ��ȭ
    public GameObject Redcode;   //�۾� ����
    public GameObject Blackcode; //�۾� ħü
    //-------------------------------------------------

    void Start()
    {
        InvokeRepeating("AddCode", 3, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {



    }


    public void AddCode()  //�ڵ带 ����
    {
        int Num = RandomCode();
        if (Num == 0)
        {
            Instantiate(Greencode, gameObject.transform);
            Debug.Log("�׸��ڵ� ����");
        }
        if (Num == 1)
        {
            Instantiate(Redcode, gameObject.transform);
            Debug.Log("�����ڵ� ����");
        }
        if (Num == 2)
        {
            Instantiate(Blackcode, gameObject.transform);
            Debug.Log("���ڵ� ����");
        }

    }


    int RandomCode()
    {
        int CodeNum;
        int a = Random.Range(0, 100);

        if(a < 70)
        {
            CodeNum = 0;
        }
        else if(a<90)
        {
            CodeNum = 1;
        }
        else
        {
            CodeNum = 2;
        }
        return CodeNum;
    }

}