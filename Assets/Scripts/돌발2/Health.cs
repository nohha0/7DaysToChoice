using UnityEngine;

public class Health : MonoBehaviour
{
    public Transform minYObject; // �ּ� y ��ġ�� ������ ������Ʈ
    public Transform maxYObject; // �ִ� y ��ġ�� ������ ������Ʈ
    public float minSpeed = 1f; // ü�� �̵��� �ּ� �ӵ�
    public float maxSpeed = 3f; // ü�� �̵��� �ִ� �ӵ�
    public float minPauseTime = 2f; // �����ִ� �ּ� �ð�
    public float maxPauseTime = 6f; // �����ִ� �ִ� �ð�

    private float currentSpeed; // ���� ü�� �̵� �ӵ�
    private bool isMoving = false; // ü�� ���� ������ ����
    private float pauseTimer; // �����ִ� �ð��� �����ϴ� Ÿ�̸�
    private float destination; // �������� ��������

    public float slowSpeed;

    private void Start()
    {
        currentSpeed = Random.Range(minSpeed, maxSpeed); // �ӵ��� �������� ����
        SetDestination(); // �������� ����
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveHealthBar();
        }
        else
        {
            pauseTimer -= Time.deltaTime;
            if (pauseTimer <= 0f)
            {
                ResumeMovement();
            }
        }
    }

    private void MoveHealthBar()
    {
        // ü�� �̵� ������ �����մϴ�.
        // ���÷� ü�� �ٸ� ���Ϸ� �̵���ŵ�ϴ�.
        float distanceToDestination = Mathf.Abs(transform.position.y - destination);
        float speedMultiplier = Mathf.Lerp(0.2f, 2f, Mathf.Clamp01(distanceToDestination / 150f) * slowSpeed);
        transform.Translate(Vector3.up * currentSpeed * speedMultiplier * Time.deltaTime);

        // ���������� �����ϸ� �������� ���ߵ��� �����մϴ�.
        if ((currentSpeed > 0f && transform.position.y >= destination) ||
            (currentSpeed < 0f && transform.position.y <= destination))
        {
            StopMovement();
        }
    }

    private void StopMovement()
    {
        isMoving = false; // �������� ���ߵ��� �����մϴ�.
        pauseTimer = Random.Range(minPauseTime, maxPauseTime); // �����ִ� �ð��� �������� �����մϴ�.
    }

    private void ResumeMovement()
    {
        isMoving = true; // �������� �簳�ϵ��� �����մϴ�.
        SetDestination(); // ���������� ���� �����մϴ�.
    }

    private void SetDestination()
    {
        float minY = minYObject.position.y; 
        float maxY = maxYObject.position.y; 

        // ���������� �������� �����մϴ�.
        destination = Random.Range(minY, maxY);

        if(destination < minY)
        {
            destination = minY;
        }
        if(destination > maxY)
        {
            destination = maxY;
        }


        // ���� ��ġ�� ������������ ���� �ִ� ���, �Ʒ��� �����̵��� ����
        if (transform.position.y > destination)
        {
            currentSpeed = -Mathf.Abs(currentSpeed);
        }
        // ���� ��ġ�� ������������ �Ʒ��� �ִ� ���, ���� �����̵��� ����
        else
        {
            currentSpeed = Mathf.Abs(currentSpeed);
        }
    }
}