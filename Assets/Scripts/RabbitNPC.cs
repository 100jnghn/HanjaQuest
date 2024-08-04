using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabbitNPC : MonoBehaviour
{
    public RabbitGameManager rabbitGameManager;

    int index = 0;
    string[] ownText =
    {
        "����",
        "�䳢�� ����� ��¼��",
        "10�� �̻� ������ �ȵ�",
        "ó������"
    };

    public GameObject spawnPoint;
    public GameObject uiCanvas;
    public Text npcText;
    public Text btnText;

    void Start()
    {
        npcText.text = ownText[index];
    }

    void Update()
    {
        
    }

    public void nextText()
    {
        index++;

        // ������ ��ȭ ����
        if (index == ownText.Length - 1)
        {
            btnText.text = "Ȯ��";
            npcText.text = ownText[index];
        }

        // ��ȭ ����
        else if (index >= ownText.Length)
        {
            index = 0;
            uiCanvas.SetActive(false);

            rabbitGameManager.gameStart();
        }
        else
        {
            npcText.text = ownText[index];
        }
    }
}
