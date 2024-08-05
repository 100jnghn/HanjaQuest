using BeyondLimitsStudios.VRInteractables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanjaModel : MonoBehaviour
{
    public GameObject[] hanjas;    // 한자 오브젝트 배열
    public GameObject[] images;    // 한자에 대응하는 이미지 배열
    public GameObject completionCanvas; // 모든 한자가 완료된 후 표시할 캔버스
    public GameObject posObject;

    public updateAccuracy accuracy;
    public mapMove mapMover;

    private int currentHanjaIndex = 0;  // 현재 표시할 한자 인덱스
    private bool allHanjaComplete = false; // 모든 한자 완료 여부 확인

    void Start()
    {
        DisplayCurrentHanja(); // 게임 시작 시 첫 번째 한자와 이미지를 표시
    }

    void Update()
    {
        // 스페이스바를 눌렀을 때 다음 한자로 이동
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextHanja();
        }
        // 정확도가 70 이상일 때 다음 한자로 이동
/*        if (accuracy.data.accuracy >= 5.0f && !allHanjaComplete)
        {
            NextHanja();
        }*/
    }

    // 현재 인덱스의 한자와 이미지를 화면에 표시
    public void DisplayCurrentHanja()
    {
        updateAccuracy.zeroAccuracy();
        DrawingBoardTexture.clearAll();
        BrushCube.count();

        // 모든 한자와 이미지를 비활성화
        foreach (var hanja in hanjas)
        {
            hanja.SetActive(false);
        }

        foreach (var image in images)
        {
            image.SetActive(false);
        }

        // 현재 인덱스의 한자와 이미지를 활성화
        if (currentHanjaIndex < hanjas.Length && currentHanjaIndex < images.Length)
        {

            Vector3 position = posObject.transform.position;

            // 한자 모델과 이미지를 posObject 위치로 이동
            hanjas[currentHanjaIndex].transform.position = position;
            images[currentHanjaIndex].transform.position = position;

            hanjas[currentHanjaIndex].SetActive(true);
            images[currentHanjaIndex].SetActive(true);
        }

    }

    // 다음 한자 및 이미지로 이동
    public void NextHanja()
    {
        // mapMove 스크립트에서 이동 시작
        if (mapMover != null)
        {
            mapMover.StartMove();
        }

        if (currentHanjaIndex < hanjas.Length - 1)
        {
            currentHanjaIndex++;
            DisplayCurrentHanja();
        }
        else
        {
            // 인덱스가 배열의 끝에 도달하면 완료 캔버스를 2초 뒤에 활성화
            if (completionCanvas != null)
            {
                StartCoroutine(ActivateCompletionCanvasAfterDelay(2f));
            }
            allHanjaComplete = true; // 모든 한자가 완료되었음을 표시
        }
    }

    private IEnumerator ActivateCompletionCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        completionCanvas.SetActive(true);
    }
}
