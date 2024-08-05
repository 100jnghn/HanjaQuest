using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanjaModel : MonoBehaviour
{
    public GameObject[] hanjas;    // ���� ������Ʈ �迭
    public GameObject[] images;    // ���ڿ� �����ϴ� �̹��� �迭
    public GameObject completionCanvas; // ��� ���ڰ� �Ϸ�� �� ǥ���� ĵ����
    public GameObject posObject;

    private int currentHanjaIndex = 0;  // ���� ǥ���� ���� �ε���
    private bool allHanjaComplete = false; // ��� ���� �Ϸ� ���� Ȯ��

    void Start()
    {
        DisplayCurrentHanja(); // ���� ���� �� ù ��° ���ڿ� �̹����� ǥ��
        completionCanvas.SetActive(false); // ���� �� �Ϸ� ĵ���� ��Ȱ��ȭ
    }

    void Update()
    {
        // ��Ȯ���� 70 �̻��� �� ���� ���ڷ� �̵�

    }

    // ���� �ε����� ���ڿ� �̹����� ȭ�鿡 ǥ��
    public void DisplayCurrentHanja()
    {
        // ��� ���ڿ� �̹����� ��Ȱ��ȭ
        foreach (var hanja in hanjas)
        {
            hanja.SetActive(false);
        }

        foreach (var image in images)
        {
            image.SetActive(false);
        }

        // ���� �ε����� ���ڿ� �̹����� Ȱ��ȭ
        if (currentHanjaIndex < hanjas.Length && currentHanjaIndex < images.Length)
        {

            Vector3 position = posObject.transform.position;

            // ���� �𵨰� �̹����� posObject ��ġ�� �̵�
            hanjas[currentHanjaIndex].transform.position = position;
            images[currentHanjaIndex].transform.position = position;

            hanjas[currentHanjaIndex].SetActive(true);
            images[currentHanjaIndex].SetActive(true);
        }
        else
        {
            // �ε����� �迭�� ���� �����ϸ� �Ϸ� ĵ���� Ȱ��ȭ
            completionCanvas.SetActive(true);
            allHanjaComplete = true; // ��� ���ڰ� �Ϸ�Ǿ����� ǥ��
        }
    }

    // ���� ���� �� �̹����� �̵�
    public void NextHanja()
    {
        // ���� ���ڷ� �̵��ϱ� ���� ��Ȯ���� �ʱ�ȭ
        updateAccuracy.zeroAccuracy?.Invoke();

        if (currentHanjaIndex < hanjas.Length - 1)
        {
            currentHanjaIndex++;
            DisplayCurrentHanja();
        }
        else
        {
            // �ε����� �迭�� ���� �����ϸ� �Ϸ� ĵ���� Ȱ��ȭ
            completionCanvas.SetActive(true);
            allHanjaComplete = true; // ��� ���ڰ� �Ϸ�Ǿ����� ǥ��
        }
    }
}
