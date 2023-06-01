using UnityEngine;
using UnityEngine.EventSystems;

public class HealthBar : MonoBehaviour
{
    public float forceMagnitude = 10f; // ������ ���� ũ��

    private Rigidbody2D targetRigidbody; // ���� ������ ������Ʈ�� Rigidbody2D ������Ʈ

    private void Start()
    {
        targetRigidbody = GetComponentInParent<Rigidbody2D>(); // ���� ������Ʈ�� �θ� ������Ʈ���� Rigidbody2D�� ã���ϴ�.
    }


    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            // ���콺 Ŭ�� �� ���� ���� ������ ����մϴ�.
            Vector2 forceDirection = Vector2.up;

            // ���� ������ ������Ʈ�� ���� ���մϴ�.
            if (targetRigidbody != null)
            {
                targetRigidbody.AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse);
            }
        }
    }
}