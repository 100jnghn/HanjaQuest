using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BeyondLimitsStudios.VRInteractables;

public class ClearCanvas : MonoBehaviour
{
    public GameObject[] objectsToHide; // 비활성화할 오브젝트 배열
    public Button[] buttons; // 버튼 배열
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
        // 클릭된 버튼에 따라 오브젝트를 비활성화
        HideObjects();

        // 여기서 각 버튼에 대한 추가 로직을 작성
        Debug.Log(button.name + " clicked!");
    }

    public void HideObjects()
    {
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false); // 오브젝트를 비활성ghk
        }
        data.correctCube = 0;
        data.wrongCube = 0;
        data.totalAnswerCube = 0;
        data.missedCube = 0;
        data.accuracy = 0;
        DrawingBoardTexture.clearAll();
    }
}
