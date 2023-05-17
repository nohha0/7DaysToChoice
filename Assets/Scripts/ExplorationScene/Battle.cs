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
    public GameObject BattleUI; //전투 종료하고 UI 끌 때 사용
    public GameObject TargetBar; //프리팹 - 랜덤 X좌표에 5개 생성
    public GameObject PlayerBar; //프리팹 - 특정 위치에서 생성하면 알아서 감
    public bool playerTurn;
    public bool enemyTurn;
    public float createTime;
    public float deleteTime;
    public int turnNumber = 0;

    [System.NonSerialized]
    ExplorationController expCon;
    int TargetPosX; //타겟 바가 생성될 X좌표값(랜덤값) 담는 곳
    GameObject player;
    GameObject target;
    int Damage;
    

    void Start()
    {
        Debug.Log("배틀 시작!");
        PlayerTurn();
        expCon = GameObject.Find("Canvas").GetComponent<ExplorationController>();
    }

    void Update()
    {

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
        Damage = damage;

        //에너미 hp 데이터 처리

        //생성했던 Target들 삭제
        Invoke("DeleteTargetBar", 1f);

        //데미지 효과 UI 처리 (캐릭터 진동, 데미지량 표시)
        DamageUI.GetComponent<Text>().text = damage.ToString();
        Invoke("onDamageUI", 1f);
        Invoke("offDamageUI", 2f);

        //대화창으로 알림
        Invoke("onBattleDialog", 1.5f);
        Invoke("offBattleDialog", 1f); //아. 저 함수를 InVoke로 할 게 아니고, 여기서 멈춰서 사용자 입력 기다리는게 일반적이긴 하네.


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
        Damage = damage;

        //플레이어 hp 처리

        Invoke("PlayerTurn", 5f);
        //PlayerTurn();
        //대화창 UI 표시 - 공격/도망간다
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
            battleDialog.GetComponent<Text>().text = $"상대에게 {Damage}만큼의 피해를 입혔다. 이제 상대가 공격할 차례다.";
        }

        if (enemyTurn)
        {
            battleDialog.GetComponent<Text>().text = $"내가 {Damage}만큼의 피해를 입었다. 이제 내가 공격할 차례다.";
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
        Debug.Log("배틀 2: 타겟 바 삭제!");
    }

    void DeletePlayerBar()
    {
        Destroy(player);
        Debug.Log("배틀 4: 플레이어 바 삭제!");
    }

    void CloseBattle()
    {
        Debug.Log("배틀 종료!");
        expCon.offTouched();
        BattleUI.SetActive(false);
    }
}
