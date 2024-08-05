using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearCanvas : MonoBehaviour
{
    public GameObject[] objectsToHide; // ��Ȱ��ȭ�� ������Ʈ �迭
    public Button[] buttons; // ��ư �迭

    void Start()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    private void OnButtonClick(Button button)
    {
        // Ŭ���� ��ư�� ���� ������Ʈ�� ��Ȱ��ȭ
        HideObjects();

        // ���⼭ �� ��ư�� ���� �߰� ������ �ۼ�
        Debug.Log(button.name + " clicked!");
    }

    public void HideObjects()
    {
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false); // ������Ʈ�� ��Ȱ��ȭ
        }
    }
}
