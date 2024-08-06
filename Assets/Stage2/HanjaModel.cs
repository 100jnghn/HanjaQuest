using BeyondLimitsStudios.VRInteractables;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using BeyondLimitsStudios.VRInteractables;


public class HanjaModel : MonoBehaviour
{
    public GameObject[] hanjas;    // 한자 오브젝트 배열
    public GameObject[] images;    // 한자에 대응하는 이미지 배열
    public GameObject completionCanvas; // 모든 한자가 완료된 후 표시할 캔버스
    public GameObject posObject;
    public TMP_Text showingCharacter;   // UI에 표시할 monster 고유 한자
    public GameObject canvas; // 클리어 후 비활성화 할 캔버스
    public GameObject canvas2; // 클리어 후 마지막 대사

    public updateAccuracy accuracy;
    public mapMove mapMover;

    private int currentHanjaIndex = 0;  // 현재 표시할 한자 인덱스
    private bool allHanjaComplete = false; // 모든 한자 완료 여부 확인

    public AudioSource Answer;
    public AudioSource Clear;

    public Music m;

    void Start()
    {
        showingCharacter.text = "";
        DisplayCurrentHanja(); // 게임 시작 시 첫 번째 한자와 이미지를 표시
    }

    void Update()
    {
        // 스페이스바를 눌렀을 때 다음 한자로 이동
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(NextHanjaWithDelay());
        }
        // 정확도가 일정 이상일 때 다음 한자로 이동
        if (accuracy != null && accuracy.data != null && accuracy.data.accuracy >= 0.3f)
        {
            StartCoroutine(NextHanjaWithDelay());
        }
    }

    // 현재 인덱스의 한자와 이미지를 화면에 표시
    public void DisplayCurrentHanja()
    {
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

            showingCharacter.SetText(images[currentHanjaIndex].name);

            hanjas[currentHanjaIndex].SetActive(true);
            images[currentHanjaIndex].SetActive(true);
        }

    }

    // 다음 한자 및 이미지로 이동
    public void NextHanja()
    {
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

    private IEnumerator NextHanjaWithDelay()
    {
        BoardScript.SetTex(); //텍스쳐 저장
        HanjaSkill.Activate(); //애니메이션 재생

        updateAccuracy.zeroAccuracy();
        DrawingBoardTexture.clearAll();
        DrawTest.initAnswer();
        BrushCube.count();

        // Answer.Play()를 즉시 실행
        Answer.Play();
        // mapMove 스크립트에서 이동 시작
        if (mapMover != null)
        {
            mapMover.StartMove();
        }
        // 1초 대기 후 NextHanja 실행
        yield return new WaitForSeconds(1f);
        NextHanja();
    }

    private IEnumerator ActivateCompletionCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canvas.SetActive(false);
        canvas2.SetActive(true);
        completionCanvas.SetActive(true);
        m.otherMusic.Stop();
        Clear.Play();
    }
}
