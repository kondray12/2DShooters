using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f; // �������� �������� �����
    public float moveDistance = 4.0f; // ����������, �� ������� ���� ����� ��������� ������ � �����

    private Vector3 originalPosition;
    private bool moveForward = true;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (moveForward)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        // �������� �� ���������� ������������� ����������
        if (Vector3.Distance(originalPosition, transform.position) >= moveDistance)
        {
            // �������� ����������� ��������
            moveForward = !moveForward;
        }
    }
}
