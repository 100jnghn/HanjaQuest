using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSuccess : MonoBehaviour
{
    public Transform Player;
    public Transform teleportTarget; // �ڷ���Ʈ�� ��ǥ ��ġ
    public GameObject nextPanel;  // ��Ÿ�� �г�
    public GameObject destroyPanel; // ���� �г�
    public GameObject summon; // ��ȯ��ų ����

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

        nextPanel.SetActive(true); // �г� Ȱ��ȭ

        summon.SetActive(true); // ���ӿ�����Ʈ Ȱ��ȭ

        destroyPanel.SetActive(false);

        Destroy(gameObject); // �� ��ũ��Ʈ�� �ִ� ���� ������Ʈ ����
    }

}
