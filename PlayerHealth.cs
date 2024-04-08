using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingLives = 3; // Начальное количество жизней
    private int currentLives; // Текущее количество жизней
    public Text liveText; // Ссылка на текстовый элемент для отображения жизней
    public Text gameOverText; // Ссылка на текстовый элемент для отображения сообщения "Вы проиграли"
    public float restartDelay = 2f; // Задержка перед перезапуском уровня
    public GameObject deathPanel; // Ссылка на панель для затемнения экрана
    private bool gameOver = false; // Флаг для проверки окончания игры
    
    
 

    void Start()
    {
        currentLives = startingLives;
        UpdateLiveText();
        gameOverText.gameObject.SetActive(false); // Скрываем текст "Вы проиграли" в начале игры
        deathPanel.SetActive(false);// Скрываем панель в начале игры
    }

    // Метод для уменьшения количества жизней
    public void TakeDamage()
    {
        if (gameOver)
            return; // Если игра уже закончена, игнорируем урон

        currentLives--;
        UpdateLiveText();

        if (currentLives <= 0)
        {
            // Если закончились жизни, завершаем игру
            GameOver();
        }
    }

    // Метод для обновления отображения жизней в текстовом элементе
    private void UpdateLiveText()
    {
        liveText.text = "Lives: " + currentLives;
    }

    // Метод для окончания игры
    private void GameOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true); // Отображаем текст "Вы проиграли"
        deathPanel.SetActive(true); // Показываем затемненный экран

        // Здесь можно добавить другие действия, такие как остановка игрового времени, блокировка управления и т. д.

        // Запустить перезагрузку уровня через задержку
        Invoke("RestartLevel", restartDelay);
    }

    // Метод для перезапуска уровня
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
