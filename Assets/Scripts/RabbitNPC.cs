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
        "������~~! �̴�δ� �� ��..",
        "�ȳ�! ū�ϳ���!!!",
        "���� ��� ��Ȳ�̾�!",
        "�䳢���� ���ڱ� ����� �������̷� ����԰� �־�.",
        "��ҿ��� �̷� ���� �����µ�...",
        "�䳢�鿡�� ��� ����� ����ٸ�",
        "�츮 ������ ū ���ظ� ���� ��.",
        "�� ���¸� �� �۹����� �� ������ �ž�,",
        "ȥ�ڼ��� �����ϱ� �����..",
        "��Ź�̾�, �� �����༭ �� ��Ȳ�� ó������!",
        "�䳢���� ����� 10�� �̻� ���� �ʵ��� ������."
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

        // ������ ��ȭ ����
        if (index == ownText.Length - 1)
        {
            btnText.text = "Ȯ��";
            npcText.text = ownText[index];
            setAnimation();
        }

        // ��ȭ ����
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
