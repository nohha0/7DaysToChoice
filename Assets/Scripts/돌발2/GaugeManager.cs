using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeManager : MonoBehaviour
{
    public Image gaugeImage; // �������� ǥ���� �̹���
    public float fillRate = 1f; // �������� �ʱ� �ʷ� ��
    public float increaseSpeed = 1f; // �浹 �� �������� �ö󰡴� �ӵ�
    public float decreaseSpeed = 1f; // �浹�� ���� �� �������� �������� �ӵ�

    public bool GaugeStart = true; // ������ �۵� ���θ� ��Ÿ���� ����

    public GameObject arrowGame; // Ȱ��ȭ�� ArrowGame ������Ʈ

    private bool isColliding = false; // �浹 ���¸� ��Ÿ���� �÷���
    private float currentFill = 0f; // ���� �������� ä�� ����


    bool delay = false;

    private void Start()
    {
        // �������� �ʱ� ���� �ʷ� ������ �����մϴ�.
        currentFill = fillRate;

        // ������ �̹����� �ʱ� ���� �ݿ��մϴ�.
        gaugeImage.fillAmount = currentFill;
    }

    private void Update()
    {
        if (!GaugeStart)
            return;

        if (isColliding)
        {
            // �浹 ���� ��� �������� ������ŵ�ϴ�.
            currentFill += increaseSpeed * Time.deltaTime;
        }
        else if(!isColliding&& !delay)
        {
            // �浹�� ���� ��� �������� ���ҽ�ŵ�ϴ�.
            currentFill -= decreaseSpeed * Time.deltaTime;

            // �ʷ� ���� 0���� �۾����� ó���մϴ�.
            if (currentFill < 0f)
            {
                currentFill = 1;
                delay = true;
                Invoke("DelayFalse", 2f);
                GameManager.Heart--;

            }
        }

        // �������� ä�� ������ 0�� 1 ���̷� �����մϴ�.
        currentFill = Mathf.Clamp01(currentFill);

        // ������ �̹����� ä�� ������ �ݿ��մϴ�.
        gaugeImage.fillAmount = currentFill;

        /*
        // �������� ���� á�� �� ���� ������Ʈ�� Ȱ��ȭ�մϴ�.
        if (currentFill >= 1f)
        {
            GaugeStart = false; // ������ �۵� ����

            // ArrowGame ������Ʈ�� Ȱ��ȭ�մϴ�.
            if (arrowGame != null)
            {
                arrowGame.SetActive(true);
            }
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            Debug.Log("������ ����");
            isColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            Debug.Log("������ ����");
            isColliding = false;
        }
    }
    void DelayFalse()
    {
        delay = false;
    }
}