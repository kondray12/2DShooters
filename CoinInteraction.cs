using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CoinInteraction : MonoBehaviour
{
    

    private UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ��� ��������������� � ����������, ���������� �������
            Destroy(gameObject);

            uiManager.IncreaseScore(1);

        }
    }
   


}
