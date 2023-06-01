using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject GameStart; // GameStart 오브젝트를 연결할 변수

    private void Update()
    {
        // 마우스 클릭 입력 감지
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Q))
        {
            // GameStart 오브젝트 활성화
            if (GameStart != null)
                GameStart.SetActive(true);

            // 현재 오브젝트 비활성화
            gameObject.SetActive(false);
        }
    }
}