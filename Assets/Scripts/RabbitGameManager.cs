using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using BeyondLimitsStudios.VRInteractables;
using UnityEngine.UI;
using UnityEngine.InputSystem.Composites;
using System.Security.Cryptography;

public class RabbitGameManager : MonoBehaviour
{
    public Queue<GameObject> monsterQ;  // 씬에 있는 monster를 관리하는 큐

    public GameObject drawHanjaCanvas;  // 한자 그리는 캔버스
    public GameObject clearPanel;   // 클리어 시 띄우는 UI 패널
    public GameObject failpanel;    // 실패 시 띄우는 UI 패널

    public GameObject spawnPoint;   // rabbit monster 스폰 위치
    public CarrotBox carrotBox;     // 당근 상자 -> 당근의 수 count 
    public TMP_Text showingCharacter;   // UI에 표시할 monster 고유 한자
    public Text remainTimeText;     // 남은 시간 표시하는 텍스트
    public Text remainCarrotText;   // 남은 당근 표시하는 텍스트
    public Timer timer;             // 타이머 (남은 시간) 

    public AudioSource bgm;         // 게임 bgm
    public AudioSource clearSound;  // 성공 효과음
    public AudioSource failSound;   // 실패 효과음
    public GameObject[] hanjas;
    public GameObject[] Images;

    //public GameObject hanjaPos;

    public updateAccuracy updateAccuracy;   // 정확도를 가져오기 위한 변수
    public float dieScore;                  // dieScore 이상이면 monster 죽습니다

    public bool isGaming;


    void Start()
    {
        monsterQ = new Queue<GameObject>();
    }

    void Update()
    {
        // 큐가 비었으면 한자 표시 X
        if (monsterQ.Count == 0)
        {
            showingCharacter.text = "";
        }

        remainCarrotText.text = "남은 당근: " + carrotBox.carrotCount.ToString();

        // 당근 다 털리면 게임 종료
        if (carrotBox.carrotCount <= 0)
        {
            if (isGaming)
            {
                gameOver();

                // 실패 UI
                failpanel.SetActive(true);

                // 실패 sfx
                failSound.Play();
            }           
        }

        // 남은 시간 표시
        remainTimeText.text = "남은 시간: " + ((int)timer.remainTime).ToString();

        // 게임 시간 종료(클리어)
        if (timer.remainTime <= 0)
        {
            if (isGaming)
            {
                gameOver();

                // 클리어 UI
                clearPanel.SetActive(true);

                // 클리어 sfx
                clearSound.Play();
            }
        }

        // dieScore 이상이면 Monster 죽여버림
        checkAccuracy();
    }

    // 게임 시작
    public void gameStart()
    {
        isGaming = true;
        spawnPoint.SetActive(true);
        timer.isStarting = true;
        drawHanjaCanvas.SetActive(true);
        bgm.Play();
    }

    // 게임 종료 (미완)
    public void gameOver()
    {
        isGaming = false;
        timer.isStarting = false;
        drawHanjaCanvas.SetActive(false);
        bgm.Stop();
        Destroy(spawnPoint);
    }

    public void enqueue(GameObject rabbit)  // 큐에 몬스터 push()
    {
        monsterQ.Enqueue(rabbit);

        // 큐에 처음으로 mosnter 들어옴
        if (monsterQ.Count == 1)
        {
            Debug.Log("MonsterQ 1");
            updateCharacter();
        }
    }

    public void dequeue()   // 큐에서 몬스터 pop()
    {
        if (monsterQ.Count > 0)
        {
            monsterQ.Dequeue();
            updateCharacter();
        }
    }


    // UI에 표시할 한자 update
    void updateCharacter()
    {
        if (monsterQ.Count > 0)
        {
            GameObject firstMonster = monsterQ.Peek();
            Monster nMonster = firstMonster.GetComponent<Monster>();
            Debug.Log(nMonster.ownCharacter);

            showingCharacter.SetText(nMonster.ownCharacter);
            FindHanja(nMonster.ownCharacter);

            // 정확도 0으로 초기화
            updateAccuracy.zeroAccuracy();
        }
    }

    // 정확도가 n이상일 때 mosnter 제거
    void checkAccuracy()
    {
        if (isGaming && monsterQ.Count > 0)
        {
            if (updateAccuracy.data.accuracy > dieScore)
            {
                GameObject firstMonster = monsterQ.Peek();
                Monster nMonster = firstMonster.GetComponent<Monster>();
                nMonster.die();
            }
        }
    }

    void FindHanja(string name)
    {
        for (int i = 0; i < hanjas.Length; i++)
        {
            hanjas[i].SetActive(false);
            Images[i].SetActive(false);
        }
        switch (name)
        {
            case "달 월":
                hanjas[0].SetActive(true);
                //Images[0].SetActive(true);
                break;
            case "불 화":
                //nstantiate(hanjas[1], hanjaPos.transform.position, hanjaPos.transform.rotation);
                hanjas[1].SetActive(true);
                //Images[1].SetActive(true);
                break;
            case "물 수":
                //Instantiate(hanjas[2], hanjaPos.transform.position, hanjaPos.transform.rotation);
                hanjas[2].SetActive(true);
                //Images[2].SetActive(true);
                break;
            case "나무 목":
                //Instantiate(hanjas[3], hanjaPos.transform.position, hanjaPos.transform.rotation);
                hanjas[3].SetActive(true);
                //Images[3].SetActive(true);
                break;
            case "쇠 금":
                //Instantiate(hanjas[4], hanjaPos.transform.position, hanjaPos.transform.rotation);
                hanjas[4].SetActive(true);
                //Images[4].SetActive(true);
                break;
            case "흙 토":
                //Instantiate(hanjas[5], hanjaPos.transform.position, hanjaPos.transform.rotation);
                hanjas[5].SetActive(true);
                //Images[5].SetActive(true);
                break;
            case "날 일":
                //Instantiate(hanjas[6], hanjaPos.transform.position, hanjaPos.transform.rotation);
                hanjas[6].SetActive(true);
                //Images[6].SetActive(true);
                break;
        }
        DrawingBoardTexture.clearAll();
        BrushCube.count();
        DrawTest.initAnswer();
        DrawTest.initTmp();

        /*foreach (Transform child in transform)
        {
            Debug.Log(child.gameObject.name);
            child.gameObject.tag = "miss";
            Renderer renderer = child.GetComponent<Renderer>();
            renderer.material.color = Color.white;

        }
        for (int i = 0; i < 2500; i++)
        {
            transform.GetChild(i).gameObject.tag="miss";
            Renderer renderer = transform.GetChild(i).GetComponent<Renderer>();
            renderer.material.color = Color.white;
        }
        */
        //Invoke("BrushCube.count()", 1f);
    }


    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
