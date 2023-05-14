using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public GameObject BattleUI; //���� �����ϰ� UI �� �� ���
    public GameObject TargetBar; //������ - ���� X��ǥ�� 5�� ����
    public GameObject PlayerBar; //������ - Ư�� ��ġ���� �����ϸ� �˾Ƽ� ��
    public bool playerTurn;
    public bool enemyTurn;

    [System.NonSerialized]
    public List<GameObject> Targets; //��ǥ�� ��� ��
    int TargetPosX; //Ÿ�� �ٰ� ������ X��ǥ��(������) ��� ��

    void Start()
    {
        playerTurn = true;
        enemyTurn = false;
        CreateTarget();
        Invoke("CreateBullet", 1f);
    }

    void Update()
    {

    }

    void CreateTarget()
    {
        //������ �����ؼ� �ֱ�
    }

    void CreateBullet()
    {
        Vector3 bulletPosition = new Vector3(-6f, -3.5f, 0f);
        Instantiate(PlayerBar, bulletPosition, Quaternion.identity);
    }

    void GiveDamageToEnemy(int damage)
    {
        //�ο�� �����ϸ� ���� UI ������ Start �޼��� ���� -> Bullet �ʿ��� ���� ������ �ڿ� �� �޼��� ������
        //bullet�ʿ��� damage �״�� ������ ���� ó��
        

        //�� �ѱ��
        playerTurn = false;
        enemyTurn = true;

        //TakeDamageFromEnemy
    }

    void TakeDamageFromEnemy(int damage)
    {
        //�÷��̾����� ���� ó��


        //�� �ѱ��
        playerTurn = true;
        enemyTurn = false;

        //��ȭâ UI ǥ�� - ����/��������
        //���� ������ GiveDamageToEnemy
    }

    void StartBattle()
    {

    }

}
