using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHits = 3; // ������������ ���������� ���������, ����� �������� ���� ��������

    private int currentHits = 0; // ������� ���������� ���������


    private UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log(currentHits);
            // ���� ���� ����� � ����, ����������� ������� ���������
            currentHits++;

            // ���������� ����
            Destroy(other.gameObject);

            // ���������, �������� �� ���������� ��������� ������������� ��������
            if (currentHits >= maxHits)
            {
                uiManager.IncreaseScore(2);

                // ���� ��, �� ���������� �����
                Destroy(gameObject);
            }
        }
    }
}
