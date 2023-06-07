using UnityEngine;
using UnityEngine.UI;

public class DistanceManager : MonoBehaviour
{
    public Text distanceText; // UI 텍스트 오브젝트를 연결할 변수
    public float speed = 1f; // 거리가 줄어드는 속도
    //public


    bool TimeStop = false;

    private void Update()
    {
        if(TimeStop)
        {
            // 시간에 따라 거리가 줄어들도록 계산
            GameManager.distance -= speed * Time.deltaTime;
        }
        

        // 거리 텍스트 업데이트
        UpdateDistanceText();
    }

    private void UpdateDistanceText()
    {
        // 텍스트 내용을 포맷에 맞게 업데이트
        string text = "다음 지점까지: " + GameManager.distance.ToString("F2") + " m";
        distanceText.text = text;
    }

    void Zerodistance()
    {
        if(GameManager.distance < 0 )
        {
            TimeStop = true;
            GameManager.distance = 0;
        }
    }
}