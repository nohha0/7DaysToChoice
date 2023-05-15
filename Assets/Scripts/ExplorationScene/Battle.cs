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
    public float createTime;
    public float deleteTime;
    public List<GameObject> Targets;
    public int turnNumber = 0;

    [System.NonSerialized]
    int TargetPosX; //Ÿ�� �ٰ� ������ X��ǥ��(������) ��� ��
    GameObject player;
    GameObject target;
    


    void Start()
    {
        PlayerTurn();
    }

    void Update()
    {

    }

    void CreateTarget()
    {
        float randomX;
        Vector3 targetPosition;

        for (int i = -2; i < 2; i++)
        {
            randomX = Random.Range(i * 1.7f, (i+1) * 1.7f);
            targetPosition = new Vector3(randomX, -3.5f, 0f);
            target = (GameObject)Instantiate(TargetBar, targetPosition, Quaternion.identity);
            Targets.Add(target);
        }
    }

    void CreatePlayerBar()
    {
        //Vector3 bulletPosition = new Vector3(-6f, -3.5f, 0f);
        Vector3 bulletPosition = new Vector3(-10f, -3.5f, 0f);
        player = Instantiate(PlayerBar, bulletPosition, Quaternion.identity);
    }

    public void GiveDamageToEnemy(int damage)
    {
        /* �÷��̾� �� */

        //�ο�� �����ϸ� ���� UI ������ Start �޼��� ���� -> Bullet �ʿ��� ���� ������ �ڿ� �� �޼��� ������
        //bullet�ʿ��� damage �״�� ������ ���� ó��
        Debug.Log($"��Ʋ 1: ������ ���ظ� {damage}��ŭ ������!");

        //���ʹ� hp ó��

        //�����ߴ� Target�� ����
        Invoke("DeleteTargetBar", 1f);

        //�� �ѱ��
        playerTurn = false;
        enemyTurn = true;

        TakeDamageFromEnemy();
    }

    public void TakeDamageFromEnemy()
    {
        /* ���ʹ� �� */

        //�÷��̾����� ���� ó��
        int damage = Random.Range(10, 20);
        Debug.Log($"��Ʋ 3: ���� ���ظ� {damage}��ŭ �Ծ���!");

        //�÷��̾� hp ó��

        Invoke("PlayerTurn", 5f);
        //PlayerTurn();
        //��ȭâ UI ǥ�� - ����/��������
    }

    void PlayerTurn()
    {
        if (turnNumber >= 3) return;

        //���� �� �÷��̾� �Ϻ��� ������
        playerTurn = true;
        enemyTurn = false;

        //��ǥ�� 5�� ����, 1�� �� �÷��̾�� ����
        CreateTarget();
        Invoke("CreatePlayerBar", createTime);
        Invoke("DeletePlayerBar", deleteTime);

        turnNumber++;

        if (turnNumber >= 3)
        {
            Invoke("CloseBattle", deleteTime);
        }
    }

    void DeleteTargetBar()
    {
        foreach (var target in Targets)
        {
            Destroy(target);
        }
        Targets.Clear();
        Debug.Log("��Ʋ 2: Ÿ�� �� ����!");
    }

    void DeletePlayerBar()
    {
        Destroy(player);
        Debug.Log("��Ʋ 4: �÷��̾� �� ����!");
    }

    void CloseBattle()
    {
        BattleUI.SetActive(false);
    }
}
