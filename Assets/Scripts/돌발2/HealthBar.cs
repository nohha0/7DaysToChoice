using UnityEngine;
using UnityEngine.EventSystems;


public class HealthBar : MonoBehaviour
{
    public Rigidbody targetRigidbody; // ���� ������ ������Ʈ�� Rigidbody ������Ʈ
    public float forceMagnitude = 10f; // ������ ���� ũ��

    private void Start()
    {
        targetRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 Ŭ�� �� ���� ���� ������ ����մϴ�.
            Vector3 forceDirection = Vector3.up;

            // ���� ������ ������Ʈ�� ���� ���մϴ�.
            targetRigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
        }
    }
}