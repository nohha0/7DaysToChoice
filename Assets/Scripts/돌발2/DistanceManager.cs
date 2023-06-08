using UnityEngine;
using UnityEngine.UI;

public class DistanceManager : MonoBehaviour
{
    public Text distanceText; // UI �ؽ�Ʈ ������Ʈ�� ������ ����
    public float speed = 1f; // �Ÿ��� �پ��� �ӵ�
    public GameObject HeartGame;
    public GameObject ArrowGame;
    public GameObject Heart;  // ��Ʈ���ӿ�����Ʈ ����
    public GameObject GaugeBar; //�������� ����
    public Transform min;


    bool TimeStop = false;


    private void Start()
    {
        GameManager.distance = 10;
    }

    private void Update()
    {
        if(!TimeStop)
        {
            // �ð��� ���� �Ÿ��� �پ�鵵�� ���
            GameManager.distance -= speed * Time.deltaTime;
        }
        

        // �Ÿ� �ؽ�Ʈ ������Ʈ
        UpdateDistanceText();
        Zerodistance();
    }

    private void UpdateDistanceText()
    {
        // �ؽ�Ʈ ������ ���˿� �°� ������Ʈ
        string text = "���� ��������: " + GameManager.distance.ToString("F2") + " m";
        distanceText.text = text;
    }

    void Zerodistance()
    {

        
        if(GameManager.distance <= 0 && !TimeStop)
        {
            TimeStop = true;
            GameManager.distance = 0;
            Heart.transform.position = new Vector3(Heart.transform.position.x, min.position.y, Heart.transform.position.z);  //��Ʈ ��ġ �ʱ�ȭ
            GaugeBar.transform.position = new Vector3(GaugeBar.transform.position.x, min.position.y+0.5f, GaugeBar.transform.position.z);  //��Ʈ ��ġ �ʱ�ȭ
            HeartGame.SetActive(false);  //������ ���� ��Ȱ��ȭ
            GameManager.isCheakLound = true; //����Ű���� ����
            ArrowGame.SetActive(true); //����Ű ���� Ȱ��ȭ
            

        }
        if(TimeStop&&GameManager.distance >10 )
        {
            TimeStop = false;
        }
    }
}