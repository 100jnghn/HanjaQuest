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
        "도와줘~~~",
        "안녕!",
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
