using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб пули
    public Transform bulletSpawnPoint; // Место, откуда будут выпускаться пули
    public float bulletSpeed = 10f; // Скорость пуль
    public float fireRate = 1f; // Частота выстрелов в выстрелах в секунду
    public float bulletLifetime = 10f; // Время жизни пули в секундах

    private float nextFireTime = 0f; // Время следующего возможного выстрела

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate; // Обновляем время следующего возможного выстрела
        }
    }

    void Shoot()
    {
        


        // Создаем экземпляр пули из префаба
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Настройка скорости пули
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = bullet.transform.forward * bulletSpeed;

        // Уничтожаем пулю через указанное время (bulletLifetime)
        Destroy(bullet, bulletLifetime);

    }
}
