using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHits = 3; // ћаксимальное количество попаданий, после которого враг исчезает

    private int currentHits = 0; // “екущее количество попаданий


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
            // ≈сли враг попал в пулю, увеличиваем счетчик попаданий
            currentHits++;

            // ”ничтожаем пулю
            Destroy(other.gameObject);

            // ѕровер€ем, достигло ли количество попаданий максимального значени€
            if (currentHits >= maxHits)
            {
                uiManager.IncreaseScore(2);

                // ≈сли да, то уничтожаем врага
                Destroy(gameObject);
            }
        }
    }
}
