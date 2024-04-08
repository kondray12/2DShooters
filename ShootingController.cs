using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ����
    public Transform bulletSpawnPoint; // �����, ������ ����� ����������� ����
    public float bulletSpeed = 10f; // �������� ����
    public float fireRate = 1f; // ������� ��������� � ��������� � �������
    public float bulletLifetime = 10f; // ����� ����� ���� � ��������

    private float nextFireTime = 0f; // ����� ���������� ���������� ��������

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate; // ��������� ����� ���������� ���������� ��������
        }
    }

    void Shoot()
    {
        


        // ������� ��������� ���� �� �������
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // ��������� �������� ����
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = bullet.transform.forward * bulletSpeed;

        // ���������� ���� ����� ��������� ����� (bulletLifetime)
        Destroy(bullet, bulletLifetime);

    }
}
