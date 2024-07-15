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
        "ㅎㅇ",
        "토끼가 당근을 어쩌구",
        "10개 이상 먹으면 안됨",
        "처리해줘"
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

        // 마지막 대화 도달
        if (index == ownText.Length - 1)
        {
            btnText.text = "확인";
            npcText.text = ownText[index];
        }

        // 대화 종료
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
