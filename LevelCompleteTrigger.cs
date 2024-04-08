using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteTrigger : MonoBehaviour
{
    public GameObject completePanel; // Ссылка на панель для отображения сообщения
    public Text messageText; // Ссылка на текстовый элемент для отображения сообщения

    


    

    void Start() {
        messageText.gameObject.SetActive(false); // Скрываем текст "Вы проиграли" в начале игры
        completePanel.SetActive(false);// Скрываем панель в начале игры
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
   
            // Показать сообщение о прохождении уровня и опцию начать сначала
            completePanel.SetActive(true);
            messageText.gameObject.SetActive(true);

            // Останавливаем движение игрока (если у вас есть скрипт управления)
            //other.GetComponent<MovmentPlayer>().enabled = false;
        }
    }
}
