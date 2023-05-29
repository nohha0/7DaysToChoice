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
        // ȭ�� ��ġ�� �����ϰ� SetActive�� �����մϴ�.
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
            // ���콺 Ŭ�� ��ġ�� ��ũ�� ��ǥ���� ���� ��ǥ�� ��ȯ
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // ����ĳ��Ʈ�� ���� Ŭ���� ��� Ȯ��
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