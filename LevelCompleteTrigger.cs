using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteTrigger : MonoBehaviour
{
    public GameObject completePanel; // ������ �� ������ ��� ����������� ���������
    public Text messageText; // ������ �� ��������� ������� ��� ����������� ���������

    


    

    void Start() {
        messageText.gameObject.SetActive(false); // �������� ����� "�� ���������" � ������ ����
        completePanel.SetActive(false);// �������� ������ � ������ ����
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
   
            // �������� ��������� � ����������� ������ � ����� ������ �������
            completePanel.SetActive(true);
            messageText.gameObject.SetActive(true);

            // ������������� �������� ������ (���� � ��� ���� ������ ����������)
            //other.GetComponent<MovmentPlayer>().enabled = false;
        }
    }
}
