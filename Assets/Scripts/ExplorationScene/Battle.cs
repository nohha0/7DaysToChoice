using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public GameObject BattleUI; //전투 종료하고 UI 끌 때 사용
    public List<GameObject> Targets; //목표물
    public GameObject bulletPrefab; //프리팹
    public Vector3 bulletPosition; //인스펙터창에서 설정
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

    void CreateBullet()
    {
        //Instantiate(bulletPrefab, bulletPosition);
    }
}
