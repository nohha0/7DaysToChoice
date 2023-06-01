using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject GameStart; // GameStart ������Ʈ�� ������ ����

    private void Update()
    {
        // ���콺 Ŭ�� �Է� ����
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Q))
        {
            // GameStart ������Ʈ Ȱ��ȭ
            if (GameStart != null)
                GameStart.SetActive(true);

            // ���� ������Ʈ ��Ȱ��ȭ
            gameObject.SetActive(false);
        }
    }
}