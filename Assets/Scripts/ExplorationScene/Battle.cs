using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public List<GameObject> Targets;
    public GameObject DamageUI;
    public GameObject battleDialog;
    public GameObject battleBackground;
    public GameObject BattleUI; //���� �����ϰ� UI �� �� ���
    public GameObject TargetBar; //������ - ���� X��ǥ�� 5�� ����
    public GameObject PlayerBar; //������ - Ư�� ��ġ���� �����ϸ� �˾Ƽ� ��
    public bool playerTurn;
    public bool enemyTurn;
    public float createTime;
    public float deleteTime;
    public int turnNumber = 0;

    [System.NonSerialized]
    ExplorationController expCon;
    int TargetPosX; //Ÿ�� �ٰ� ������ X��ǥ��(������) ��� ��
    GameObject player;
    GameObject target;
    int Damage;
    

    void Start()
    {
        Debug.Log("��Ʋ ����!");
        PlayerTurn();
        expCon = GameObject.Find("Canvas").GetComponent<ExplorationController>();
    }

    void Update()
    {

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
        Damage = damage;

        //���ʹ� hp ������ ó��

        //�����ߴ� Target�� ����
        Invoke("DeleteTargetBar", 1f);

        //������ ȿ�� UI ó�� (ĳ���� ����, �������� ǥ��)
        DamageUI.GetComponent<Text>().text = damage.ToString();
        Invoke("onDamageUI", 1f);
        Invoke("offDamageUI", 2f);

        //��ȭâ���� �˸�
        Invoke("onBattleDialog", 1.5f);
        Invoke("offBattleDialog", 1f); //��. �� �Լ��� InVoke�� �� �� �ƴϰ�, ���⼭ ���缭 ����� �Է� ��ٸ��°� �Ϲ����̱� �ϳ�.


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
        Damage = damage;

        //�÷��̾� hp ó��

        Invoke("PlayerTurn", 5f);
        //PlayerTurn();
        //��ȭâ UI ǥ�� - ����/��������
    }

    public void onDamageUI()
    {
        DamageUI.SetActive(true);
    }

    public void offDamageUI()
    {
        DamageUI.SetActive(false);
    }

    public void onBattleDialog()
    {
        battleBackground.SetActive(false);

        if (playerTurn)
        {
            battleDialog.GetComponent<Text>().text = $"��뿡�� {Damage}��ŭ�� ���ظ� ������. ���� ��밡 ������ ���ʴ�.";
        }

        if (enemyTurn)
        {
            battleDialog.GetComponent<Text>().text = $"���� {Damage}��ŭ�� ���ظ� �Ծ���. ���� ���� ������ ���ʴ�.";
        }

        battleDialog.SetActive(true);
    }

    public void offBattleDialog()
    {
        battleDialog.SetActive(false);
        battleBackground.SetActive(true);
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
        Debug.Log("��Ʋ ����!");
        expCon.offTouched();
        BattleUI.SetActive(false);
    }
}
