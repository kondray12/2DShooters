using UnityEngine;

public class BulletController : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        // ��� ������������ � ������ ��������, ���������� ����
        Destroy(gameObject);
    }
}
