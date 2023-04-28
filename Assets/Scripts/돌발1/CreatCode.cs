using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatCode : MonoBehaviour
{
    public GameObject Greencode; //�۾� Ȱ��ȭ
    public GameObject Redcode;   //�۾� ����
    public GameObject Blackcode; //�۾� ħü
    //-------------------------------------------------
    public Transform StartPos;

    GameManager1 Code;
    bool ControllOn = false;
    void Start()
    {
        Code = GameObject.Find("GameManager").GetComponent<GameManager1>();
        InvokeRepeating("AddCode", 3, 2f);
    }

    // Update is called once per frame
    void Update()
    {

        if(Code.AddCodeStop)
        {
            CancelInvoke("AddCode");
            ControllOn = true;
        }
        if(ControllOn&& !Code.AddCodeStop)
        {
            InvokeRepeating("AddCode", 0, 2f);
            ControllOn = false;
        }


    }


    public void AddCode()  //�ڵ带 ����
    {
        int Num = RandomCode();
        if (Num == 0)
        {
            GameObject newObject = Instantiate(Greencode);
            newObject.transform.parent = null;
            newObject.transform.position = StartPos.position;

            Debug.Log("�׸��ڵ� ����");
        }
        if (Num == 1)
        {
            GameObject newObject = Instantiate(Redcode);
            newObject.transform.parent = null;
            newObject.transform.position = StartPos.position;
            Debug.Log("�����ڵ� ����");
        }
        if (Num == 2)
        {
            GameObject newObject = Instantiate(Blackcode);
            newObject.transform.parent = null;
            newObject.transform.position = StartPos.position;
            Debug.Log("���ڵ� ����");
        }

    }


    int RandomCode()
    {
        int CodeNum;
        int a = Random.Range(0, 100);

        if(a < 65)
        {
            CodeNum = 0;
        }
        else if(a<85)
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