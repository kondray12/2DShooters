using UnityEngine;

public class BulletController : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        // При столкновении с другим объектом, уничтожаем пулю
        Destroy(gameObject);
    }
}
