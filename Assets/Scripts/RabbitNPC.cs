using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabbitNPC : MonoBehaviour
{
    public RabbitGameManager rabbitGameManager;
    public Animator animator;
    public AudioSource btnClickSound;

    int index = 0;
    string[] ownText =
    {
        "도와줘~~! 이대로는 안 돼..",
        "안녕! 큰일났어!!!",
        "정말 긴급 상황이야!",
        "토끼들이 갑자기 당근을 마구잡이로 뺏어먹고 있어.",
        "평소에는 이런 일이 없었는데...",
        "토끼들에게 계속 당근을 뺏긴다면",
        "우리 가족은 큰 손해를 보게 돼.",
        "이 상태면 내 작물들이 다 망가질 거야,",
        "혼자서는 감당하기 힘드네..",
        "부탁이야, 날 도와줘서 이 상황을 처리해줘!",
        "토끼들이 당근을 10개 이상 먹지 않도록 도와줘."
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
        btnClickSound.Play();

        // 마지막 대화 도달
        if (index == ownText.Length - 1)
        {
            btnText.text = "확인";
            npcText.text = ownText[index];
            setAnimation();
        }

        // 대화 종료
        else if (index >= ownText.Length)
        {
            index = 0;
            uiCanvas.SetActive(false);

            Invoke("gameStartWithDelay", 1.5f);
        }
        else
        {
            npcText.text = ownText[index];
            setAnimation();
        }
    }

    void gameStartWithDelay()
    {
        rabbitGameManager.gameStart();
    }

    void setAnimation()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            animator.SetTrigger("talking1");
        }
        else if (rand == 1)
        {
            animator.SetTrigger("talking2");
        }
    }
}
