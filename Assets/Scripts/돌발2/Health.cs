using UnityEngine;

public class Health : MonoBehaviour
{
    public Transform minYObject; // �ּ� y ��ġ�� ������ ������Ʈ
    public Transform maxYObject; // �ִ� y ��ġ�� ������ ������Ʈ
    public float minSpeed = 1f; // ü�� �̵��� �ּ� �ӵ�
    public float maxSpeed = 3f; // ü�� �̵��� �ִ� �ӵ�
    public float minPauseTime = 2f; // �����ִ� �ּ� �ð�
    public float maxPauseTime = 6f; // �����ִ� �ִ� �ð�
    public float maxRange;

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
        float speedMultiplier = Mathf.Lerp(0.2f, 2.5f, Mathf.Clamp01(distanceToDestination / 150f) * slowSpeed);
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
        float minDestination = Mathf.Max(transform.position.y - Random.Range(2f,maxRange), minY);
        float maxDestination = Mathf.Min(transform.position.y + Random.Range(2f,maxRange), maxY);

        int a = Random.Range(0, 2);
        if(a == 0)
        {
            destination = minDestination;
        }
        else
        {
            destination = maxDestination;
        }

        if (destination < minY)
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