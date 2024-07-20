using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSuccess : MonoBehaviour
{
    public Transform Player;
    public Transform teleportTarget; // 텔레포트할 목표 위치
    public GameObject nextPanel;  // 나타낼 패널
    public GameObject destroyPanel; // 없앨 패널
    public GameObject summon; // 소환시킬 무언가

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("TeleportAndShow", 2f);
        }
    }

    void TeleportAndShow()
    {
        Player.transform.position = teleportTarget.position;

        nextPanel.SetActive(true); // 패널 활성화

        summon.SetActive(true); // 게임오브젝트 활성화

        destroyPanel.SetActive(false);

        Destroy(gameObject); // 이 스크립트가 있는 게임 오브젝트 삭제
    }

}
