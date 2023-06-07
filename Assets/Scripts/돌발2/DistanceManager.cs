using UnityEngine;
using UnityEngine.UI;

public class DistanceManager : MonoBehaviour
{
    public Text distanceText; // UI �ؽ�Ʈ ������Ʈ�� ������ ����
    public float speed = 1f; // �Ÿ��� �پ��� �ӵ�
    //public


    bool TimeStop = false;

    private void Update()
    {
        if(TimeStop)
        {
            // �ð��� ���� �Ÿ��� �پ�鵵�� ���
            GameManager.distance -= speed * Time.deltaTime;
        }
        

        // �Ÿ� �ؽ�Ʈ ������Ʈ
        UpdateDistanceText();
    }

    private void UpdateDistanceText()
    {
        // �ؽ�Ʈ ������ ���˿� �°� ������Ʈ
        string text = "���� ��������: " + GameManager.distance.ToString("F2") + " m";
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