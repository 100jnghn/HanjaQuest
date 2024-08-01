using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UI�� ����ϱ� ���� �ʿ�

public class HanjaModel : MonoBehaviour
{
    public LinkData linkData;          // ���� ������ ����
    public Transform modelSpawnPos;    // �� ���� ��ġ
    public Image completionImage;      // ��� ���� ������ �� ��Ÿ�� �̹���

    private int currentIndex = 0;      // ���� ������ �ε���
    private bool isSpawning = false;   // ���� ���θ� Ȯ���ϱ� ���� �÷���
    private GameObject currentModel;   // ���� ������ ���� ������ ����

    void Start()
    {
        isSpawning = false;
        if (completionImage != null)
        {
            completionImage.gameObject.SetActive(false); // ���� �� �̹����� ����ϴ�.
        }
    }

    // ��ư Ŭ������ ȣ��Ǿ� ���� ����
    public void StartSpawning()
    {
        isSpawning = true;
        SpawnNextHanja(); // ��� ù ��° ���� ����
    }

    void Update()
    {
        // �����̽��ٸ� ������ �� ���� ���� ����
        if (isSpawning && Input.GetKeyDown(KeyCode.Space))
        {
            SpawnNextHanja();
        }
    }

    void SpawnNextHanja()
    {
        // ���� ������ ���� ������ ����
        if (currentModel != null)
        {
            Destroy(currentModel);
        }

        // ���� ���� �� ����
        if (currentIndex < linkData.hanjaDataList.Count)
        {
            var entry = linkData.hanjaDataList[currentIndex];
            Data hanjaData = entry.value;

            // ���ο� ���� �����ϰ� ����
            currentModel = Instantiate(hanjaData.model, modelSpawnPos.position, modelSpawnPos.rotation);

            currentIndex++; // ���� �ε����� �̵�
        }
        else
        {
            Debug.Log("��� ���� ���� �����Ǿ����ϴ�.");
            isSpawning = false; // ��� ���� �����Ǹ� ���� ����

            // ��� ���� ������ �� �̹��� Ȱ��ȭ
            if (completionImage != null)
            {
                completionImage.gameObject.SetActive(true);
            }
        }
    }
}
