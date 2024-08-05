using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BeyondLimitsStudios.VRInteractables;

public class ClearCanvas : MonoBehaviour
{
    public GameObject[] objectsToHide; // ��Ȱ��ȭ�� ������Ʈ �迭
    public Button[] buttons; // ��ư �迭
    public Data data;

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
            obj.SetActive(false); // ������Ʈ�� ��Ȱ��ghk
        }
        data.correctCube = 0;
        data.wrongCube = 0;
        data.totalAnswerCube = 0;
        data.missedCube = 0;
        data.accuracy = 0;
        DrawingBoardTexture.clearAll();
    }
}
