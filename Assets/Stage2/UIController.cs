using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button startButton; // ��ư ������Ʈ
    public HanjaModel hanjaSpawner; // HanjaSpawner ������Ʈ

    void Start()
    {
        // ��ư Ŭ�� �̺�Ʈ�� �ڵ鷯 �߰�
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
