using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public GameObject BattleUI; //전투 종료하고 UI 끌 때 사용
    public GameObject TargetBar; //프리팹 - 랜덤 X좌표에 5개 생성
    public GameObject PlayerBar; //프리팹 - 특정 위치에서 생성하면 알아서 감
    public bool playerTurn;
    public bool enemyTurn;
    public float createTime;
    public float deleteTime;
    public List<GameObject> Targets;
    public int turnNumber = 0;

    [System.NonSerialized]
    int TargetPosX; //타겟 바가 생성될 X좌표값(랜덤값) 담는 곳
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
        /* 플레이어 턴 */

        //싸운다 선택하면 전투 UI 켜지고 Start 메서드 실행 -> Bullet 쪽에서 점수 집계한 뒤에 이 메서드 실행함
        //bullet쪽에서 damage 그대로 적에게 공격 처리
        Debug.Log($"배틀 1: 적에게 피해를 {damage}만큼 입혔다!");

        //에너미 hp 처리

        //생성했던 Target들 삭제
        Invoke("DeleteTargetBar", 1f);

        //턴 넘기기
        playerTurn = false;
        enemyTurn = true;

        TakeDamageFromEnemy();
    }

    public void TakeDamageFromEnemy()
    {
        /* 에너미 턴 */

        //플레이어한테 공격 처리
        int damage = Random.Range(10, 20);
        Debug.Log($"배틀 3: 내가 피해를 {damage}만큼 입었다!");

        //플레이어 hp 처리

        Invoke("PlayerTurn", 5f);
        //PlayerTurn();
        //대화창 UI 표시 - 공격/도망간다
    }

    void PlayerTurn()
    {
        if (turnNumber >= 3) return;

        //시작 시 플레이어 턴부터 시작함
        playerTurn = true;
        enemyTurn = false;

        //목표물 5개 생성, 1초 뒤 플레이어바 생성
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
        Debug.Log("배틀 2: 타겟 바 삭제!");
    }

    void DeletePlayerBar()
    {
        Destroy(player);
        Debug.Log("배틀 4: 플레이어 바 삭제!");
    }

    void CloseBattle()
    {
        BattleUI.SetActive(false);
    }
}
