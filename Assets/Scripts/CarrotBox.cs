using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotBox : MonoBehaviour
{
    public RabbitGameManager rabbitGameManager;

    public int carrotCount = 10;    // ���Ѿ� �� ����� ��  // 0 �Ǹ� ����
    public float timer = 0f;        // �ð� ��� ����
    public float limitTime = 3f;    // 3�� ������ ���--
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // Monster(�䳢)�� �浹�ϴ� ���� Ÿ�̸� ���
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            // Debug.Log("Monster Collision");
            timer += Time.deltaTime;

            if (timer > limitTime)
            {
                Destroy(collision.gameObject);  // �䳢 ����
                rabbitGameManager.dequeue();    // ť���� �䳢 obj ����

                carrotCount--;
                timer = 0;
            }
        }
    }
}
