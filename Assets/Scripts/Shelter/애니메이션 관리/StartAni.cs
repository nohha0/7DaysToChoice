using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAni : MonoBehaviour
{
    Animator animator;

    private bool isActive = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // 화면 터치를 감지하고 SetActive를 변경합니다.
        if(gameObject.activeSelf)
        {
            if(!isActive)
            {
                isActive = true;
                gameObject.SetActive(true);
                animator.SetTrigger("start");
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 클릭 위치를 스크린 좌표에서 월드 좌표로 변환
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 레이캐스트를 통해 클릭한 대상 확인
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);


            if (hit.collider != null && hit.collider.gameObject != gameObject)
            {
                if (isActive)
                {
                    isActive = false;
                    gameObject.SetActive(false);
                }
            }
            

        }
    }

    public void ActiveStart()
    {
        gameObject.SetActive(true);
    }
}