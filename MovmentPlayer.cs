using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovmentPlayer : MonoBehaviour
{

    public float moveSpeed = 5f; // Скорость передвижения
    public float jumpForce = 8f; // Сила прыжка
    private bool isGrounded = false; // Флаг для проверки, находится ли персонаж на земле
    private Rigidbody rb;
    private UIManager uiManager;
    private float currentTime = 0f; // Текущее значение времени
    private float timeIncrement = 1f; // Увеличение времени за кадр
    private PlayerHealth playerHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        uiManager = FindObjectOfType<UIManager>();
        playerHealth = GetComponent<PlayerHealth>();
        

    }
    void Update()
    {

        // Проверка, находится ли персонаж на земле (прикосновение к земле)
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.8f);

        // Управление движением влево и вправо
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Прыжок
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        currentTime += timeIncrement * Time.deltaTime;

        uiManager.UpdateTime(currentTime);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            RestartLevel();
        }

        if (transform.position.y < -30)
        {

            playerHealth.TakeDamage();
            
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Обработка столкновения с врагом (уменьшение жизней)
            playerHealth.TakeDamage();
        }
    }

    public void RestartLevel()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}
