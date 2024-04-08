using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingLives = 3; // ��������� ���������� ������
    private int currentLives; // ������� ���������� ������
    public Text liveText; // ������ �� ��������� ������� ��� ����������� ������
    public Text gameOverText; // ������ �� ��������� ������� ��� ����������� ��������� "�� ���������"
    public float restartDelay = 2f; // �������� ����� ������������ ������
    public GameObject deathPanel; // ������ �� ������ ��� ���������� ������
    private bool gameOver = false; // ���� ��� �������� ��������� ����
    
    
 

    void Start()
    {
        currentLives = startingLives;
        UpdateLiveText();
        gameOverText.gameObject.SetActive(false); // �������� ����� "�� ���������" � ������ ����
        deathPanel.SetActive(false);// �������� ������ � ������ ����
    }

    // ����� ��� ���������� ���������� ������
    public void TakeDamage()
    {
        if (gameOver)
            return; // ���� ���� ��� ���������, ���������� ����

        currentLives--;
        UpdateLiveText();

        if (currentLives <= 0)
        {
            // ���� ����������� �����, ��������� ����
            GameOver();
        }
    }

    // ����� ��� ���������� ����������� ������ � ��������� ��������
    private void UpdateLiveText()
    {
        liveText.text = "Lives: " + currentLives;
    }

    // ����� ��� ��������� ����
    private void GameOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true); // ���������� ����� "�� ���������"
        deathPanel.SetActive(true); // ���������� ����������� �����

        // ����� ����� �������� ������ ��������, ����� ��� ��������� �������� �������, ���������� ���������� � �. �.

        // ��������� ������������ ������ ����� ��������
        Invoke("RestartLevel", restartDelay);
    }

    // ����� ��� ����������� ������
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
