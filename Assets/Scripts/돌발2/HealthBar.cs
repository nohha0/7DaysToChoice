using UnityEngine;
using UnityEngine.EventSystems;


public class HealthBar : MonoBehaviour
{
    public Rigidbody targetRigidbody; // 힘이 가해질 오브젝트의 Rigidbody 컴포넌트
    public float forceMagnitude = 10f; // 적용할 힘의 크기

    private void Start()
    {
        targetRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 클릭 시 힘을 가할 방향을 계산합니다.
            Vector3 forceDirection = Vector3.up;

            // 힘이 가해질 오브젝트에 힘을 가합니다.
            targetRigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
        }
    }
}