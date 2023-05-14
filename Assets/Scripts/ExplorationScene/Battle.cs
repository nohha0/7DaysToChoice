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

    [System.NonSerialized]
    public List<GameObject> Targets; //목표물 담는 곳
    int TargetPosX; //타겟 바가 생성될 X좌표값(랜덤값) 담는 곳

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
        //랜덤값 생성해서 넣기
    }

    void CreateBullet()
    {
        Vector3 bulletPosition = new Vector3(-6f, -3.5f, 0f);
        Instantiate(PlayerBar, bulletPosition, Quaternion.identity);
    }

    void GiveDamageToEnemy(int damage)
    {
        //싸운다 선택하면 전투 UI 켜지고 Start 메서드 실행 -> Bullet 쪽에서 점수 집계한 뒤에 이 메서드 실행함
        //bullet쪽에서 damage 그대로 적에게 공격 처리
        

        //턴 넘기기
        playerTurn = false;
        enemyTurn = true;

        //TakeDamageFromEnemy
    }

    void TakeDamageFromEnemy(int damage)
    {
        //플레이어한테 공격 처리


        //턴 넘기기
        playerTurn = true;
        enemyTurn = false;

        //대화창 UI 표시 - 공격/도망간다
        //공격 누르면 GiveDamageToEnemy
    }

    void StartBattle()
    {

    }

}
