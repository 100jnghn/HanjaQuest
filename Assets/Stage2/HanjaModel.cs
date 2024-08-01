using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UI를 사용하기 위해 필요

public class HanjaModel : MonoBehaviour
{
    public LinkData linkData;          // 한자 데이터 연결
    public Transform modelSpawnPos;    // 모델 스폰 위치
    public Image completionImage;      // 모든 모델이 스폰된 후 나타날 이미지

    private int currentIndex = 0;      // 현재 스폰할 인덱스
    private bool isSpawning = false;   // 스폰 여부를 확인하기 위한 플래그
    private GameObject currentModel;   // 현재 스폰된 모델을 저장할 변수

    void Start()
    {
        isSpawning = false;
        if (completionImage != null)
        {
            completionImage.gameObject.SetActive(false); // 시작 시 이미지를 숨깁니다.
        }
    }

    // 버튼 클릭으로 호출되어 스폰 시작
    public void StartSpawning()
    {
        isSpawning = true;
        SpawnNextHanja(); // 즉시 첫 번째 한자 스폰
    }

    void Update()
    {
        // 스페이스바를 눌렀을 때 다음 한자 스폰
        if (isSpawning && Input.GetKeyDown(KeyCode.Space))
        {
            SpawnNextHanja();
        }
    }

    void SpawnNextHanja()
    {
        // 현재 스폰된 모델이 있으면 삭제
        if (currentModel != null)
        {
            Destroy(currentModel);
        }

        // 다음 한자 모델 스폰
        if (currentIndex < linkData.hanjaDataList.Count)
        {
            var entry = linkData.hanjaDataList[currentIndex];
            Data hanjaData = entry.value;

            // 새로운 모델을 스폰하고 추적
            currentModel = Instantiate(hanjaData.model, modelSpawnPos.position, modelSpawnPos.rotation);

            currentIndex++; // 다음 인덱스로 이동
        }
        else
        {
            Debug.Log("모든 한자 모델이 스폰되었습니다.");
            isSpawning = false; // 모든 모델이 스폰되면 스폰 중지

            // 모든 모델이 스폰된 후 이미지 활성화
            if (completionImage != null)
            {
                completionImage.gameObject.SetActive(true);
            }
        }
    }
}
