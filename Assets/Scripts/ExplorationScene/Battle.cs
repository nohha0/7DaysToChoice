using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public GameObject BattleUI; //���� �����ϰ� UI �� �� ���
    public List<GameObject> Targets; //��ǥ��
    public GameObject bulletPrefab; //������
    public Vector3 bulletPosition; //�ν�����â���� ����
    public bool playerTurn;
    public bool enemyTurn;

    void Start()
    {
        playerTurn = true;
        enemyTurn = false;
        Invoke("CreateBullet", 1f);
    }

    void Update()
    {

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

    void CreateBullet()
    {
        //Instantiate(bulletPrefab, bulletPosition);
    }
}
