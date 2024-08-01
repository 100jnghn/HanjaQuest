using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button startButton; // 버튼 오브젝트
    public HanjaModel hanjaSpawner; // HanjaSpawner 오브젝트

    void Start()
    {
        // 버튼 클릭 이벤트에 핸들러 추가
        startButton.onClick.AddListener(OnStartButtonClicked);
    }

    void OnStartButtonClicked()
    {
        if (hanjaSpawner != null)
        {
            hanjaSpawner.StartSpawning();
        }
    }
}
